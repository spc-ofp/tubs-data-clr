// -----------------------------------------------------------------------
// <copyright file="DataServiceTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Tubs.DAL.Tests
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using NHibernate.Criterion;
    using NUnit.Framework;
    using PagedList;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class DataServiceTest : BaseTest
    {
        [Test]
        public void TestExecuteQuery()
        {
            IList results = TubsDataService.Execute(@"select GETDATE() AS Foo, GETDATE() AS Bar");
            Assert.NotNull(results);
            Console.WriteLine("Result Count: " + results.Count);
            foreach (object result in results)
            {
                Console.WriteLine("Result is of type: " + result.GetType());
            }
        }

        [Test]
        public void TestExecuteWithParams()
        {
            string query = @"select COUNT(*) from [TUBS_MASTER_ENTRY].[obsv].[s_day] WHERE obstrip_id = ?";
            IList results = TubsDataService.Execute(query, 70);
            Assert.NotNull(results);
            Assert.AreEqual(1, results.Count);
            Assert.IsInstanceOf<int>(results[0]);
            Assert.AreEqual(20, (int)results[0]);
        }

        [Test]
        public void DateCriteria()
        {
            // Available SQL functions are here:
            // https://github.com/nhibernate/nhibernate-core/blob/master/src/NHibernate/Dialect/MsSql2000Dialect.cs
            using (var repo = TubsDataService.GetRepository<Trip>(true))
            {
                var criteria = repo.CreateCriteria();
                criteria.Add(Restrictions.Eq(Projections.SqlFunction("year", NHibernateUtil.DateTime, Projections.Property("DepartureDate")), 2009));
                criteria.Add(Restrictions.Eq(Projections.SqlFunction("month", NHibernateUtil.DateTime, Projections.Property("DepartureDate")), 6));
                criteria.Add(Restrictions.In("CountryCode", new string[] { "MH", "PG" }));
                //criteria.Add(Restrictions.Where<Trip>(t => !t.IsDuringTrip(DateTime.Now)));
                //var programs = new InExpression("CountryCode", new string[] { "MH", "PG" });
                //criteria.Add(programs);
                var trips = criteria.List<Trip>();
                Assert.NotNull(trips);
                Assert.AreEqual(8, trips.Count());
            }
        }

        [Test]
        public void PagedList()
        {
            using (var repo = TubsDataService.GetRepository<Trip>(true))
            {
                var page = repo.All().ToPagedList(1, 10);
                Assert.AreEqual(10, page.PageSize);
                Assert.AreEqual(1, page.PageNumber);
                Assert.True(page.HasNextPage);
                Assert.False(page.HasPreviousPage);
            }
        }

        [Test]
        public void CriteriaSearch()
        {
            var criteria = new SearchCriteria();

            using (var session = TubsDataService.GetStatelessSession())
            {
                var results = TubsDataService.Search(session, criteria);
                Assert.NotNull(results);
                Assert.AreEqual(0, results.Count());

                criteria.Observer = "DJB"; // Dave Burgess, not a real observer.
                results = TubsDataService.Search(session, criteria);
                Assert.NotNull(results);
                Assert.Greater(results.Count(), 4); // Currently 6, but that changes

                criteria.ProgramCode = "PGOB";
                results = TubsDataService.Search(session, criteria);
                Assert.GreaterOrEqual(results.Count(), 1);

                criteria.ProgramCode = String.Empty;
                criteria.Vessel = "TUNA";
                results = TubsDataService.Search(session, criteria);
                Assert.Greater(results.Count(), 5);

                criteria.Vessel = String.Empty;
                criteria.AnyDate = new DateTime(2011, 9, 10);
                results = TubsDataService.Search(session, criteria);
                Assert.Greater(results.Count(), 1);
            }
        }
    }
}
