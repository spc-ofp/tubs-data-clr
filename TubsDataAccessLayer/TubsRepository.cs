// -----------------------------------------------------------------------
// <copyright file="TubsRepository.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
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

    /// <summary>
    /// TubsRepository wraps up NHibernate so that a repo per object type is not required.
    /// NOTE:  NHibernate considers any Session that has thrown an Exception to be in an undefined
    /// state.  Therefore, unlike JDBC, there's no point in handling exceptions here.
    /// </summary>
    /// <typeparam name="T">Any entity that can be mapped to a Fluent NHibernate entity.</typeparam>
    public class TubsRepository<T> : IDisposable where T : class
    {
        private bool _disposed; // For IDisposable
        private readonly ISession Session;

        public TubsRepository(ISession session)
        {
            this.Session = session;
        }

        public T FindBy(object id)
        {
            try
            {
                return this.Session.Get<T>(id);
            }
            catch (ObjectNotFoundException)
            {
                return null;
            }
        }

        public bool Add(T entity)
        {
            this.Session.SaveOrUpdate(entity);
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                this.Session.SaveOrUpdate(item);
            }

            return true;
        }

        /// <summary>
        /// Updates an entity.
        /// It can handle merging a disconnected object, but that _doesn't_
        /// happen by default because merges can be dangerous.
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        /// <param name="autoMerge">true to merge automatically, false to not merge</param>
        /// <returns>true if update succeeded, false otherwise</returns>
        public bool Update(T entity, bool autoMerge = false)
        {
            // This can happen if we're loading the entity from
            // another session/transaction.
            // It can also happen *ahem* if we're hydrating the object
            // from a form submission.
            bool requiresMerge = RequiresMerge(entity);

            if (requiresMerge && !autoMerge)
            {
                return false;
            }

            if (requiresMerge)
            {
                this.Session.Merge<T>(entity);
            }
            else
            {
                this.Session.SaveOrUpdate(entity);
            }
            
            return true;
        }

        public bool RequiresMerge(T entity)
        {
            return !this.Session.Contains(entity);
        }

        public bool DeleteById(object id)
        {
            var item = this.FindBy(id);
            return this.Delete(item);
        }

        public bool Delete(T entity)
        {
            if (null == entity)
            {
                return false;
            }
            this.Session.Delete(entity);
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            bool success = true;
            
            foreach (T item in entities)
            {
                if (null == item)
                {
                    success = false;
                    break;
                }

                this.Session.Delete(item);
            }

            return success;
        }

        public IQueryable<T> All()
        {
            return this.Session.Query<T>();
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Okay to suppress for LINQ expressions")]
        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return this.FilterBy(expression).SingleOrDefault();
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Okay to suppress for LINQ expressions")]
        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return this.All().Where(expression).AsQueryable();
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Okay to suppress for LINQ expressions")]
        public PagedList<T> GetPagedList(Expression<Func<T, bool>> expression, int skip, int take)
        {
            var query = this.All().Where(expression).AsQueryable();
            var count = query.Count();
            var currentPage = query.Skip(skip).Take(take).ToList();
            return new PagedList<T>()
            {
                Entities = currentPage,
                HasNext = (skip + take < count),
                HasPrevious = (skip > 0)
            };
        }

        public PagedList<T> GetPagedList(int skip, int take)
        {
            // In a perfect world, I'd rewrite this so that it uses the LINQ version...
            var query = this.All();
            var count = query.Count();
            var currentPage = query.Skip(skip).Take(take).ToList();
            return new PagedList<T>()
            {
                Entities = currentPage,
                HasNext = (skip + take < count),
                HasPrevious = (skip > 0)
            };
        }

        ~TubsRepository()
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
                    lock (this.Session)
                    {
                        if (this.Session.IsOpen)
                        {
                            this.Session.Close();
                        }
                    }
                }

                this._disposed = true;
            }
        }
    }
}