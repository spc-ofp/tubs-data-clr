// -----------------------------------------------------------------------
// <copyright file="AccessControlEventListener.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
{
    /*
    * This file is part of TUBS.
    *
    * TUBS is free software: you can redistribute it and/or modify
    * it under the terms of the GNU Affero General Public License as published by
    * the Free Software Foundation, either version 3 of the License, or
    * (at your option) any later version.
    *  
    * TUBS is distributed in the hope that it will be useful,
    * but WITHOUT ANY WARRANTY; without even the implied warranty of
    * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    * GNU Affero General Public License for more details.
    *  
    * You should have received a copy of the GNU Affero General Public License
    * along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
    */

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate.Event.Default;
    using System.Reflection;
    using NHibernate.Event;
    using NHibernate.Persister.Entity;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AccessControlEventListener : ILoadEventListener, IPostLoadEventListener, IPreLoadEventListener, IInitializeCollectionEventListener
    {
        protected const string AccessControlProperty = "AccessControl";
        
        /*
            Name            : AccessControl
            Declaring Type  : Spc.Ofp.Tubs.DAL.Entities.PurseSeineActivity
            MemberType      : Property
            PropertyType       : System.Collections.Generic.IList`1[Spc.Ofp.Tubs.DAL.Security.ActivityAce]

         */
        internal string GetEntityName(IEventSource session)
        {
            if (null == session || !session.EnabledFilters.Any())
                return String.Empty;

            // This might be even better than the LINQ below but it needs some work
            // e.g. figuring out what the hell the filterParamenterName should be
            // var entityName = @event.Session.GetFilterParameterValue(EntityNameFilter.ParamName) as string;

            // Could probably do this with a single LINQ query...
            var filter = 
                session.EnabledFilters
                    .Where(f => f.Key == EntityNameFilter.FilterName)
                    .First().Value as NHibernate.Impl.FilterImpl;
            
            // Somewhat dangerous to depend on implementation, but then again
            // we are digging in to SessionFilters for nefarious purposes
            return  filter.Parameters.ToList().First().Value.ToString();

        }

        /// <summary>
        /// OnInitializeCollection fires on the initialization of any NHibernate collection proxy.
        /// If security is enabled and the collection contains secured entities, the collection
        /// will be modified such that it will only contain entities that the current security user
        /// is allowed to see.
        /// </summary>
        /// <param name="event"></param>
        public void OnInitializeCollection(InitializeCollectionEvent @event)
        {
            // Skip processing if there is nothing to do
            if (null == @event.Collection || @event.Collection.Empty || !@event.Session.EnabledFilters.Any())
            {
                return;
            }

            // As data access library implementer, I know that secured child entities are all contained in
            // generic lists (i.e. not Set or Map)
            var collectionType = @event.Collection.GetType();
            if (collectionType.IsGenericType)
            {
                var gtype = collectionType.GetGenericArguments().First(); // This breaks on Dictionary
                if (gtype.IsSecurable())
                {
                    
                    var entityName = @event.Session.GetFilterParameterValue("EntityNameFilter.EntityName") as string;
                    // After checking NHibernate source, the persistent list and bag collections all implement the
                    // non-generic ILIst definition.
                    var values = (System.Collections.IList)@event.Collection.GetValue();
                    var securables = values.Cast<ISecurable>(); // This should be safe due to implementation check above
                    //
                    var keepers = securables.ToList().FindAll(x => x.IsLoadableFor(entityName));
                    values.Clear();
                    keepers.ForEach(x => values.Add(x));
                }

            }
        }

        public void OnLoad(NHibernate.Event.LoadEvent @event, LoadType loadType)
        {
            if (null == @event.Result)
                return;
 
            // Short circuit
            if (!ShouldContinue(@event.Session, @event.Result.GetType()))
                return;

            ISecurable securable = @event.Result as ISecurable;
            if (null == securable)
            {
                // TODO:  Consider making this an Exception...
                System.Console.WriteLine("Implements ISecurable but can't be cast as ISecurable...");
                return;
            }

            // Attempt at fixing the Day->Trip problem...
            if ("InternalLoadLazy".Equals(loadType.ToString()))
                return;

            var entityName = @event.Session.GetFilterParameterValue("EntityNameFilter.EntityName") as string;
            //bool canLoad = securable.GetAccessList().Where(ace => ace.EntityName == entityName).Any();
            System.Console.WriteLine("ACL size: {0}", securable.AccessControlList.Count());
            bool canLoad = securable.IsLoadableFor(entityName);
            System.Console.WriteLine("loadType {0}\tLockMode: {1}", loadType, @event.LockMode);
            System.Console.WriteLine("CanLoad entity {2} for organization [{0}]? {1}", entityName, canLoad, @event.Result.GetType().FullName);
            if (!canLoad)
            {
                @event.Result = null;
            }
            
        }

        internal bool ShouldContinue(IEventSource session, Type entityType)
        {
            // Ignore entities that are not ISecurable
            // The simple method doesn't work, so fall back to LINQ
            bool isSecurable = entityType.GetInterfaces().Contains(typeof(ISecurable));
            //System.Console.WriteLine("{0} IsSecurable? {1}", entityType.FullName, isSecurable);
            if (!isSecurable)
                return false;

            // If there are no enabled filters, then nothing can be done
            if (!session.EnabledFilters.Any())
                return false;
            
            return true;
        }

        /*
         * So far, this is the only thing that works for security
         * ACL via NHibernate:
         * http://www.codeproject.com/Articles/33681/Discretionary-ACL-Authorization-Security-Model-in
         * Unfortunately, throws exception which is not what we want.  KHAAAAAN!!!!! 
         */
        public void OnPostLoad(NHibernate.Event.PostLoadEvent @event)
        {
            // Short circuit
            if (!ShouldContinue(@event.Session, @event.Entity.GetType()))
                return;

            // TODO:  Convert param to static property on EntityNameFilter
            var entityName = @event.Session.GetFilterParameterValue("EntityNameFilter.EntityName") as string;
            System.Console.WriteLine("EntityName: {0}", entityName);

            var securable = @event.Entity as ISecurable;
            bool canLoad = securable.IsLoadableFor(entityName);
            System.Console.WriteLine("canLoad? {0}", canLoad);
            if (!canLoad)
            {
                @event.Session.Evict(@event.Entity);
                var msg = String.Format("Organization {0} not permitted access to this entity", entityName);
                throw new AccessDeniedException(msg);
            }                   

        }

        public void OnPreLoad(NHibernate.Event.PreLoadEvent @event)
        {
            
            
            //base.OnPreLoad(@event);

            if (@event.Entity is ISecurable)
            {
                System.Console.WriteLine("Found an ISecurable");
                
                // Only do something if Session filtering is enabled
                if (@event.Session.EnabledFilters.Any())
                {
                    System.Console.WriteLine("At least one Session filter is present");

                    // TODO:  Convert param to static property on EntityNameFilter
                    var entityName = @event.Session.GetFilterParameterValue("EntityNameFilter.EntityName") as string;                    

                    //var entityName = GetEntityName(@event.Session);
                    System.Console.WriteLine("EntityName: {0}", entityName);

                    var securable = @event.Entity as ISecurable;
                    bool canLoad = securable.IsLoadableFor(entityName);
                    System.Console.WriteLine("canLoad? {0}", canLoad);
                    //if (!canLoad) { return; }
                    if (!canLoad)
                    {
                        System.Console.WriteLine("Entity Property Names: {0}", String.Join(",", @event.Persister.PropertyNames));
                        // Per Ayende, the State is the list of properties that will be pushed into
                        // the object.  It is possible that we could remove everything that is sensitive about
                        // the entity here.
                        System.Console.WriteLine("Entity State: {0}", String.Join(",", @event.State));
                        @event.State = null;
                        
                        @event.Session.Evict(@event.Entity);
                        @event.Entity = null;
                        //@event.State
                        //throw new Exception("Yo Dawg, I heard you're not authorized");
                        //@event.Entity = null;
                        
                    }

                    /*
                    Type entityType = @event.Entity.GetType();
                    // ISecurable _should_ have an AccessControl property
                    // AccessControl should be of type:
                    // System.Collections.Generic.IList`1[Spc.Ofp.Tubs.DAL.Infrastructure.IAccessControl]
                    var accessList = entityType.GetProperty(AccessControlProperty).GetValue(@event.Entity, null);
                    
                    var acl = new List<IAccessControl>(8);
                    if (null != accessList && accessList is System.Collections.IList)
                    {
                        System.Console.WriteLine("AccessControl is present, not null, and contains {0} items", ((System.Collections.IList)accessList).Count);

                        var tempList = (System.Collections.IList)accessList;
                        foreach (var item in tempList)
                        {
                            acl.Add((IAccessControl)item);
                        }
                    }

                    System.Console.WriteLine("ACL size: {0}", acl.Count);

                    //System.Console.WriteLine("AccessControl type: {0}", accessList.GetType());
                    //System.Console.WriteLine("AccessControl contains: {0}", accessList.GetType().GetGenericArguments());
                    //Type aceType = accessList.GetType().GetGenericArguments().First();

                    //var acl = new List<IAccessControl>();
                    

                    //System.Console.WriteLine("Strongly typed ACL is null? {0}", null == acl);
                    */
                    

                }

            }

            IEntityPersister persister = @event.Persister;
            @event.Session.Interceptor.OnLoad(@event.Entity, @event.Id, @event.State, persister.PropertyNames, persister.PropertyTypes);
        }
    }
}
