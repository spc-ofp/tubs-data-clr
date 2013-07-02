// -----------------------------------------------------------------------
// <copyright file="SecureRepository.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL
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
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Engine;
    using NHibernate.Linq;
    using NHibernate.SqlCommand;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// SecureRepository extends Repository and automatically filters
    /// entities that have security restrictions using the ACL
    /// associated with said entities.
    /// </summary>
    public class SecureRepository<S, T> : Repository<S, T>
        where T : class, ISecurable
        where S : class
    {
        private readonly string _entityName;
        // If we keep the ISecurable restriction on 'T', then
        // this should always be true
        private bool _isSecurable;

        internal SecureRepository(S session, string entityName)
            : base(session)
        {            
            this._entityName = entityName;
            // Only take the hit once on determining if the
            // entity implements ISecurable
            var concreteType = typeof(T);
            this._isSecurable = concreteType.IsSecurable();
        }

        public override T FindById(object id)
        {
            var entity = base.FindById(id);
            if (!this._isSecurable || null == entity)
                return entity;

            ISecurable securable = entity as ISecurable;
            return securable.IsLoadableFor(_entityName) ?
                entity :
                null;
        }

        /// <summary>
        /// Returns all entities that the caller has access to.  Unfortunately, the current
        /// implementation has to materialize the query results before returning.
        /// Performance ain't gonna be too great for any significant entity
        /// </summary>
        /// <returns></returns>
        public override IQueryable<T> All()
        {
            if (!this._isSecurable)
                return base.All();

            if (false)
            {
                return
                    from item in base.All()
                    let s = (ISecurable)item
                    from ace in s.AccessControlList
                    where ace.EntityName == this._entityName
                    select item;




                return
                    from item in base.All()
                    let s = (ISecurable)item
                    where s.IsAllowed(this._entityName)
                    select item;
            }

            // http://hendryluk.wordpress.com/tag/nhibernate/
            // Get down into ReLinq and register an ILinqToHqlGenerator
            // implementation that would muck with the HQL and implement the join
            // we're looking for...

            /*
             * Spc.Ofp.Tubs.DAL.Tests.SecurityTest.TestPositiveLinqFilter:
             *  Remotion.Linq.Parsing.ParserException : Cannot parse expression 'securable' as it has an unsupported type. Only query sources (that is, expressions that implement IEnumerable) and query operators can be parsed.
             *  ----> Remotion.Linq.Utilities.ArgumentTypeException : Expected a type implementing IEnumerable<T>, but found 'Spc.Ofp.Tubs.DAL.Infrastructure.ISecurable'.
             *  Parameter name: expression
             */
            // ReLinq doesn't know what to do with the literal "securable" here
            // This works for strongly typed work (see TubsWeb TripController circa line 145)
            // but it's probably the cast to and from ISecurable that kills it.
            System.Linq.Expressions.Expression<Func<ISecurable, string, bool>> IsAllowed = (securable, entityName) =>
                securable.AccessControlList
                         .Where(ace => entityName.Equals(ace.EntityName, StringComparison.InvariantCultureIgnoreCase))
                         .Any();

            // http://stackoverflow.com/questions/14578113/extending-linq-to-nhibernate-with-custom-hql-generator
            // Compiling the expression to a Func is closer...
            // Spc.Ofp.Tubs.DAL.Tests.SecurityTest.TestPositiveLinqFilter:
            // System.InvalidCastException : Unable to cast object of type 'NHibernate.Hql.Ast.HqlParameter' to type 'NHibernate.Hql.Ast.HqlBooleanExpression'.
            //Func<ISecurable, string, bool> IsAllowedFunc = IsAllowed.Compile();
            //return base.All().Cast<ISecurable>().Where(x => IsAllowedFunc(x, this._entityName)).Cast<T>();

            

            //return base.All().Cast<ISecurable>().Where(IsAllowed).Cast<T>();

            // NOTE:  It's not a compile time requirement that entities that
            // implement ISecurable keep their ACL in a property called "AccessControl"
            // That said, the first time someone adds ISecurable to an entity and uses LINQ
            // to filter results, this is going to puke all over them
            // Future implementers, consider yourself warned!
            var dc = 
                DetachedCriteria.For<T>()
                                .CreateAlias("AccessControl", "ace", JoinType.InnerJoin)
                                .Add(NHibernate.Criterion.Expression.Eq("ace.EntityName", this._entityName));

            ICriteria criteria =
                this._isStateless ?
                    dc.GetExecutableCriteria((IStatelessSession)this._session) :
                    dc.GetExecutableCriteria((ISession)this._session);

            

            // NHibernate offers a Future<T> which implements IQueryable
            // Unfortunately, it's even worse than projecting the Criteria results into a List
            // and converting that to IQueryable.
            // TODO: Be on the lookout for something that goes directly from ICriteria to IQueryable
            return criteria.List<T>().AsQueryable();
        }
        
    }
}
