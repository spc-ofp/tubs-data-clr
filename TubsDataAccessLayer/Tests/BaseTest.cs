// -----------------------------------------------------------------------
// <copyright file="BaseTest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Tests
{
    using System;
    using NUnit.Framework;
    using NHibernate;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class BaseTest
    {
        protected const string SERVER_NAME = @"SPC112089\SQLEXPRESS";
        protected const string DATABASE_NAME = @"TUBS_MASTER_ENTRY";

        protected ISessionFactory SessionFactory;
        protected ISession Session;

        [SetUp]
        public void Init()
        {
            SessionFactory = TubsDataService.CreateSessionFactory(SERVER_NAME, DATABASE_NAME);
            Session = SessionFactory.OpenSession();
        }

        [TearDown]
        public void Dispose()
        {
            Session.Close();
            SessionFactory.Close();
        }
    }
}
