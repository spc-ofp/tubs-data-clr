// -----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL
{
    using System;
    using NHibernate;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        private readonly ISessionFactory sessionFactory;
        private readonly ITransaction transaction;
        public ISession Session { get; private set; }

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            Session = sessionFactory.OpenSession();
            Session.FlushMode = FlushMode.Auto;
            transaction = Session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        ~UnitOfWork()
        {
            Dispose();
        }

        public void Dispose()
        {
            lock (Session)
            {
                if (Session.IsOpen) { Session.Close(); }
            }
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            if (!transaction.IsActive)
            {
                throw new InvalidOperationException("No active transaction");
            }
            transaction.Commit();
        }

        public void Rollback()
        {
            if (transaction.IsActive)
            {
                transaction.Rollback();
            }
        }
    }
}
