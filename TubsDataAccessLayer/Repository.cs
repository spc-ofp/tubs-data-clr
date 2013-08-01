// -----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
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
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;
    using NHibernate;
    using NHibernate.Linq;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Repository implementation that hides the differences between
    /// stateless and stateful sessions.
    /// </summary>
    public class Repository<S, T> : IRepository<T>, IDisposable
        where T : class /*, IEntity // TODO: Check that all entities implement IEntity */
        where S : class
    {
        protected readonly S _session;
        protected readonly bool _isStateless;
        private bool _disposed; // For IDisposable

        // Use delegates so that we've got the same internal interface to the
        // different operations that each session type implements.
        delegate T ReturningOperation(object id);
        delegate void Operation(T entity);
        delegate void MergingOperation(T entity, bool merge);
        delegate IQueryable<T> QueryOperation();

        // Pointers to the actual functions used to perform the
        // NHibernate operations.
        // TODO:  If the repo should return null instead of throwing an exception
        // on unauthorized access, repo will need to implement these ops instead of
        // passing them on to Session/StatelessSession
        private readonly Operation CreateOperation;
        private readonly ReturningOperation ReadOperation;
        private readonly MergingOperation UpdateOperation;
        private readonly Operation DeleteOperation;
        private readonly QueryOperation ListOperation;

        /// <summary>
        /// Internal so that we can force creation via TubsDataService
        /// (I refuse to say RepositoryFactory)
        /// </summary>
        /// <param name="session"></param>
        internal Repository(S session)
        {
            this._session = session;
            this._isStateless = session is IStatelessSession;
            if (this._isStateless)
            {
                CreateOperation = (x) => GetStatelessSession().Insert(x);
                ReadOperation = (x) => GetStatelessSession().Get<T>(x);
                UpdateOperation = (x, m) => GetStatelessSession().Update(x);
                DeleteOperation = (x) => GetStatelessSession().Delete(x);
                ListOperation = () => GetStatelessSession().Query<T>();
            }
            else
            {
                CreateOperation = (x) => GetSession().SaveOrUpdate(x);
                // If a session filter is enabled, we could swap out this call
                ReadOperation = (x) => GetSession().Get<T>(x);
                UpdateOperation = (x, m) =>
                {
                    if (m)
                    {
                        GetSession().Merge(x);
                    }
                    else
                    {
                        GetSession().SaveOrUpdate(x);
                    }
                };
                DeleteOperation = (x) => GetSession().Delete(x);
                ListOperation = () => GetSession().Query<T>();
            }
        }

        protected IStatelessSession GetStatelessSession()
        {
            return this._session as IStatelessSession;
        }

        protected ISession GetSession()
        {
            return this._session as ISession;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T FindById(object id)
        {
            try
            {
                return ReadOperation(id);
            }
            catch (ObjectNotFoundException)
            {
                return null;
            }
        }

        /*
        // If Repository had a constraint on T such that it had to implement IEntity
        // _AND_ IEntity had an Id interface property, we could do this
        public virtual bool Exists(object id)
        {
            return this._isStateless ?
                GetStatelessSession().QueryOver<T>().Where(x => x.Id == id).RowCount() > 0 :
                GetSession().QueryOver<T>().Where(x => x.Id == id).RowCount() > 0;
                
        }
        */

        public void Add(T entity)
        {
            CreateOperation(entity);
        }

        public void Add(IEnumerable<T> items)
        {
            items = items ?? Enumerable.Empty<T>();
            items.ForEach(item => CreateOperation(item));
        }

        public void Update(T entity, bool autoMerge = false)
        {
            UpdateOperation(entity, autoMerge);
        }

        public void Update(IEnumerable<T> items, bool autoMerge = false)
        {
            items = items ?? Enumerable.Empty<T>();
            items.ForEach(item => UpdateOperation(item, autoMerge));
        }

        // TODO: Test me!
        public void Reload(T entity)
        {
            if (!_isStateless)
            {
                GetSession().Refresh(entity);
            }
        }

        // At this rate I'd be better off just using ISession...
        public void Evict(T entity)
        {
            if (!_isStateless)
            {
                GetSession().Evict(entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Save(T entity)
        {
            // This caused a problem with PageCount -- if the
            // entity doesn't implement IEntity, then .Save(...) does nothing
            // which is not what we want.
            if (null != entity && entity is IEntity)
            {
                var e = entity as IEntity;
                if (e.IsNew())
                {
                    Add(entity);
                }
                else
                {
                    // This is a hack for ensuring that EnteredBy/EnteredDate aren't wiped out when
                    // updating an entity from the subset of data that comes back from the web front end
                    // TODO:  Check to ensure that previous hacks are removed from calling code
                    if (entity is IAuditable)
                    {
                        var previous = FindById(e.GetPkid());
                        ((IAuditable)entity).EnteredBy = ((IAuditable)previous).EnteredBy;
                        ((IAuditable)entity).EnteredDate = ((IAuditable)previous).EnteredDate;
                    }
                    Update(entity, true);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ICriteria CreateCriteria()
        {
            return
                this._isStateless ?
                    (GetStatelessSession()).CreateCriteria<T>() :
                    (GetSession()).CreateCriteria<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public virtual ICriteria CreateCriteria(string alias)
        {
            return
                this._isStateless ?
                    (GetStatelessSession()).CreateCriteria<T>(alias) :
                    (GetSession()).CreateCriteria<T>(alias);
        }

        public virtual IMultiCriteria CreateMultiCriteria()
        {
            if (this._isStateless)
            {
                throw new InvalidOperationException("IStatelessSession doesn't support multiple criteria");
            }
            return GetSession().CreateMultiCriteria();
        }

        public void DeleteById(object id)
        {
            var item = this.FindById(id);
            this.Delete(item);
        }

        public void DeleteAllById(IEnumerable<object> keys)
        {
            keys = keys ?? Enumerable.Empty<object>();
            keys.ForEach(key => DeleteById(key));
        }

        public void Delete(T entity)
        {
            if (null == entity)
                return;
            
            DeleteOperation(entity);
        }

        public virtual IQueryable<T> All()
        {
            return ListOperation();
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Okay to suppress for LINQ expressions")]
        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return this.FilterBy(expression).SingleOrDefault();
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Okay to suppress for LINQ expressions")]
        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return this.All().Where(expression); //.AsQueryable();
        }

        ~Repository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called
            if (!this._disposed)
            {
                // If disposing is true, dispose all managed and unmanaged resources
                if (disposing)
                {
                    if (null != this._session)
                    {
                        lock (this._session)
                        {
                            if (this._isStateless)
                            {
                                if (GetStatelessSession().IsOpen)
                                {
                                    GetStatelessSession().Close();
                                }
                            }
                            else
                            {
                                if (GetSession().IsOpen)
                                {
                                    GetSession().Close();
                                }
                            }
                        }
                    }
                }

                this._disposed = true;
            }
        }


    }
}
