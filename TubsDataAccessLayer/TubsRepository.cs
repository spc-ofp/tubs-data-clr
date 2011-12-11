// -----------------------------------------------------------------------
// <copyright file="TubsRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NHibernate;
    using NHibernate.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TubsRepository<T>
    {
        private readonly ISession Session;

        public TubsRepository(ISession session)
        {
            Session = session;
        }

        public T FindBy(object id)
        {
            return Session.Get<T>(id);
        }

        public bool Add(T entity)
        {
            bool success = false;
            try
            {
                Session.Save(entity);
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
                    Session.Save(item);
                }
                success = true;
            }
            catch (Exception)
            {

            }
            return success;
        }

        public bool Update(T entity)
        {
            bool success = false;
            try
            {
                Session.Update(entity);
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
                Session.Delete(entity);
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
                    Session.Delete(item);
                }
                success = true;
            }
            catch (Exception)
            {

            }
            return success;
        }

        public IQueryable<T> All()
        {
            return Session.Query<T>();
        }

        public T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }
    }
}
