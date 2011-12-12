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
    using System.Linq;
    using NHibernate;
    using NHibernate.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <typeparam name="T">Any entity that can be mapped to a Fluent NHibernate entity.</typeparam>
    public class TubsRepository<T>
    {
        private readonly ISession Session;

        public TubsRepository(ISession session)
        {
            this.Session = session;
        }

        public T FindBy(object id)
        {
            return this.Session.Get<T>(id);
        }

        public bool Add(T entity)
        {
            bool success = false;
            try
            {
                this.Session.Save(entity);
                success = true;
            }
            catch (Exception)
            {
                // TODO Log
            }

            return success;
        }

        public bool Add(IEnumerable<T> items)
        {
            bool success = false;
            try
            {
                foreach (T item in items)
                {
                    this.Session.Save(item);
                }

                success = true;
            }
            catch (Exception)
            {
                // TODO Log
            }

            return success;
        }

        public bool Update(T entity)
        {
            bool success = false;
            try
            {
                this.Session.Update(entity);
                success = true;
            }
            catch (Exception)
            {
                // TODO Log
            }

            return success;
        }

        public bool Delete(T entity)
        {
            bool success = false;
            try
            {
                this.Session.Delete(entity);
                success = true;
            }
            catch (Exception)
            {
                // TODO Log
            }

            return success;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            bool success = false;
            try
            {
                foreach (T item in entities)
                {
                    this.Session.Delete(item);
                }

                success = true;
            }
            catch (Exception)
            {
                // TODO Log
            }

            return success;
        }

        public IQueryable<T> All()
        {
            return this.Session.Query<T>();
        }

        public T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return this.FilterBy(expression).SingleOrDefault();
        }

        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return this.All().Where(expression).AsQueryable();
        }
    }
}
