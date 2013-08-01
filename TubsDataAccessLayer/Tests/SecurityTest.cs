// -----------------------------------------------------------------------
// <copyright file="SecurityTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Tests
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
    using System.Linq;
    using NHibernate.Criterion;
    using NHibernate.SqlCommand;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Entities;
    using Spc.Ofp.Tubs.DAL.Infrastructure;
    using Spc.Ofp.Tubs.DAL.Security;
    using System;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class SecurityTest
    {
        [Test]
        [Ignore("This doesn't work at all")]
        public void FilterDayViaTripAndProgramCode([Values(25527)] int dayId)
        {
            string programCode = "FMOB";
            using (var session = TubsDataService.GetSession())
            {
                session.EnableFilter(ProgramCodeFilter.FilterName).SetParameter(ProgramCodeFilter.ParamName, programCode);
                var repo = TubsDataService.GetRepository<SeaDay>(session);
                var day = repo.FindById(dayId);
                //Assert.Null(day);
                Assert.NotNull(day);
                Assert.Null(day.Trip);
            }
        }

        [Test]
        public void SimpleTripFilterWithFindBy()
        {
            int normaTrip = 3959;
            int nfaTrip = 1311;

            string programCode = "FMOB";
            using (var session = TubsDataService.GetSession())
            {
                session.EnableFilter(ProgramCodeFilter.FilterName).SetParameter(ProgramCodeFilter.ParamName, programCode);

                var repo = TubsDataService.GetRepository<Trip>(session);
                // At least 500 NORMA trips
                Assert.Less(500, repo.All().Count());
                var trip = repo.FindBy(t => t.Id == normaTrip);
                Assert.NotNull(trip);

                // With this session filter in place, we shouldn't be able to load any NFA (PGOB) trips
                // NOTE:  This doesn't work if we use the .FindById(...) method on Repository
                trip = repo.FindBy(t => t.Id == nfaTrip);
                Assert.Null(trip);
            }
        }

        [Test]
        public void ProgramCodeFilterWithNull()
        {
            int normaTrip = 3959;
            string programCode = null;
            using (var session = TubsDataService.GetSession())
            {
                session.EnableFilter(ProgramCodeFilter.FilterName).SetParameter(ProgramCodeFilter.ParamName, programCode);

                var repo = TubsDataService.GetRepository<Trip>(session);
                Assert.AreEqual(0, repo.All().Count());
                var trip = repo.All().Where(t => t.Id == normaTrip).FirstOrDefault();
                Assert.Null(trip);
            }
        }
        
        
        [Test]
        public void SimpleTripFilter()
        {
            int normaTrip = 3959;
            int nfaTrip = 1311;

            string programCode = "FMOB";
            using (var session = TubsDataService.GetSession())
            {
                session.EnableFilter(ProgramCodeFilter.FilterName).SetParameter(ProgramCodeFilter.ParamName, programCode);

                var repo = TubsDataService.GetRepository<Trip>(session);
                // At least 500 NORMA trips
                Assert.Less(500, repo.All().Count());
                var trip = repo.All().Where(t => t.Id == normaTrip).FirstOrDefault();
                Assert.NotNull(trip);

                // With this session filter in place, we shouldn't be able to load any NFA (PGOB) trips
                // NOTE:  This doesn't work if we use the .FindById(...) method on Repository
                trip = repo.All().Where(t => t.Id == nfaTrip).FirstOrDefault();
                Assert.Null(trip);
            }
        }

        [Test]
        public void SimpleTripHeaderFilter()
        {
            int normaTrip = 3959;
            int nfaTrip = 1311;

            string programCode = "FMOB";
            using (var session = TubsDataService.GetSession())
            {
                session.EnableFilter(ProgramCodeFilter.FilterName).SetParameter(ProgramCodeFilter.ParamName, programCode);

                var repo = TubsDataService.GetRepository<TripHeader>(session);
                // At least 500 NORMA trips
                Assert.Less(500, repo.All().Count());

                var trip = repo.All().Where(t => t.Id == normaTrip).FirstOrDefault();
                Assert.NotNull(trip);

                // With this session filter in place, we shouldn't be able to load any NFA (PGOB) trips
                trip = repo.All().Where(t => t.Id == nfaTrip).FirstOrDefault();
                Assert.Null(trip);
            }
        }
        
        
        [Test]
        public void TestAclExtension()
        {
            var activity = new PurseSeineActivity();
            activity.AccessControl.Add(new ActivityAce() { EntityName = "SPC" });
            ISecurable s = activity as ISecurable;
            Assert.True(s.AclContains("SPC"));
            Assert.False(s.AclContains("FFA"));

            Assert.True(s.IsLoadableFor("SPC"));
            Assert.False(s.IsLoadableFor("FFA"));
        }

        [Test]
        public void TestTripAcl([Values(55)] int tripId)
        {
            using (var repo = TubsDataService.GetRepository<Trip>(false))
            {
                var trip = repo.FindById(tripId);
                Assert.NotNull(trip);
                Assert.NotNull(trip.AccessControl);
                Assert.True(trip.IsLoadableFor("SPC"));
            }
        }

        [Test]
        public void TestPositiveTripFilter()
        {
            int tripId = 55;
            string entityName = "SPC";
            using (var session = TubsDataService.GetSession())
            {
                // Using FFA, this test will fail when the trip correctly gets an FFA ACE.
                session.EnableFilter(EntityNameFilter.FilterName).SetParameter(EntityNameFilter.ParamName, entityName);

                var repo = TubsDataService.GetRepository<Trip>(session);
                var trip = repo.FindById(tripId) as PurseSeineTrip;
                Assert.NotNull(trip);
                Assert.NotNull(trip.SeaDays);
            }
        }

        [Test]
        public void TestNegativeTripFilter()
        {
            int tripId = 55;
            string entityName = "NCOB"; // New Caledonia should't have any interest in a purse seine trip.
            using (var session = TubsDataService.GetSession())
            {
                session.EnableFilter(EntityNameFilter.FilterName).SetParameter(EntityNameFilter.ParamName, entityName);

                var repo = TubsDataService.GetRepository<Trip>(session);
                var trip = repo.FindById(tripId) as PurseSeineTrip;
                Assert.Null(trip);
            }
        }

        [Test]
        public void TestLinqJoin()
        {
            using (var session = TubsDataService.GetSession())
            {
                using (var trepo = TubsDataService.GetRepository<Trip>(session))
                using (var arepo = TubsDataService.GetRepository<TripAce>(session))
                {
                    var trips = from t in trepo.All()
                                join a in arepo.All() on t.Id equals a.Fkid
                                where a.EntityName == "WCPFC"
                                select t;

                    Assert.NotNull(trips);
                    var tripCount = trips.Count();
                    Assert.Less(tripCount, 4000);
                    Assert.Greater(tripCount, 1000);

                    
                }
            }
        }

        [Test]
        public void TestPositiveCollectionFilter()
        {
            // TODO:  Move this hard-coded crap into a ValueProvider...
            int dayId = 114;
            string entityName = "SPC";
            // SecureRepository shouldn't be used to load entities that don't implement ISecurable?
            //using (var repo = TubsDataService.GetSecureRepository<PurseSeineSeaDay>(false, entityName))
            //{
            //    var day = repo.FindById(dayId);
            //    Assert.NotNull(day);
            //    Assert.NotNull(day.Activities);
            //    Assert.AreEqual(3, day.Activities.Count);
            //    Assert.NotNull(day.Activities.First());
            //}
        }

        [Test]
        public void TestHqlGenerator()
        {
            using (var repo = TubsDataService.GetRepository<Trip>(false))
            {
                var trips = repo.All().Where(t => t.AclContains("WCPFC"));
                Assert.NotNull(trips);
                var tripCount = trips.Count();
                Assert.Less(tripCount, 4000);
                Assert.Greater(tripCount, 1000);
            }
        }


        [Test]
        public void TestHql()
        {
            // TODO:  Try using DelegateDecompiler
            // https://github.com/hazzik/DelegateDecompiler
            string entityName = "WCPFC";
            using (var repo = TubsDataService.GetRepository<Trip>(false))
            {
                //Trip trip = null;
                //TripAce ace = null;
                //var trips = repo.All().Join(() => trip, t => t.AccessControl, () => ace, ace.EntityName == "WCPFC");
                var trips = from trip in repo.All()
                            from ace in trip.AccessControl
                            where ace.EntityName == entityName
                            select trip;




                //var trips = repo.All().Where(t => t.AclContains("WCPFC"));
                Assert.NotNull(trips);
                var tripCount = trips.Count();
                Assert.Less(tripCount, 4000);
                Assert.Greater(tripCount, 1000);
            }
        }

        [Test]
        public void TestPositiveLinqFilter()
        {
            string entityName = "WCPFC";
            using (var repo = TubsDataService.GetSecureRepository<Trip>(false, entityName))
            {
                var trips = repo.All();
                Assert.NotNull(trips);
                var tripCount = trips.Count();
                Assert.Less(tripCount, 4000);
                Assert.Greater(tripCount, 1000);
            }
        }

        [Test]
        public void TestNegativeCollectionFilter()
        {
            // TODO:  Move this hard-coded crap into a ValueProvider...
            int dayId = 114;
            string entityName = "FFA";
            //using (var repo = TubsDataService.GetSecureRepository<PurseSeineSeaDay>(false, entityName))
            //{
            //    var day = repo.FindById(dayId);
            //    Assert.NotNull(day);
            //    Assert.NotNull(day.Activities);
            //    Assert.AreEqual(0, day.Activities.Count);
            //    Assert.Null(day.Activities.FirstOrDefault());
            //}
        }
        
        [Test]
        public void TestPositiveSessionFilter([Values("SPC")] string entityName)
        {
            int dayId = 114;
            using (var session = TubsDataService.GetSession())
            {
                // Using FFA, this test will fail when the trip correctly gets an FFA ACE.
                session.EnableFilter(EntityNameFilter.FilterName).SetParameter(EntityNameFilter.ParamName, entityName);

                // Load an entity that contains securable items
                var repo = TubsDataService.GetRepository<PurseSeineSeaDay>(session);
                var day = repo.FindById(dayId);
                Assert.NotNull(day);
                Assert.NotNull(day.Activities);
                Assert.AreEqual(3, day.Activities.Count);

                // Load a securable item directly
                var arepo = TubsDataService.GetRepository<PurseSeineActivity>(session);
                var activity = arepo.FindById(1000);
                Assert.NotNull(activity);
            }
        }
        
        [Test]
        public void TestNegativeSessionFilter([Values("FFA")] string entityName)
        {
            // Currently SPC, SPOB, and WCPFC.  Should include FFA but that record hasn't been inserted...
            int dayId = 114; // Holds activity with Id of 1000
            using (var session = TubsDataService.GetSession())
            {              
                // Using FFA, this test will fail when the trip correctly gets an FFA ACE.
                session.EnableFilter(EntityNameFilter.FilterName).SetParameter(EntityNameFilter.ParamName, entityName);

                // Load a securable item directly
                var arepo = TubsDataService.GetRepository<PurseSeineActivity>(session);
                var activity = arepo.FindById(1000);
                Assert.Null(activity);

                // Load an entity that contains securable items
                var repo = TubsDataService.GetRepository<PurseSeineSeaDay>(session);
                var day = repo.FindById(dayId);
                Assert.NotNull(day);
                Assert.NotNull(day.Activities);
                Assert.AreEqual(0, day.Activities.Count);
            }
        }

        public void KickTheTires([Values("WCPFC")] string entityName)
        {
            Trip trip = null;
            IAccessControl ace = null;

            using (var session = TubsDataService.GetStatelessSession())
            {
                var query = session.QueryOver<Trip>(() => trip)
                                   .JoinAlias(() => trip.AccessControl, () => ace, JoinType.InnerJoin)
                                   .Where(() => ace.EntityName == entityName);

                var trips = query.Take(5).List();
                var count = trips.Count;
                Assert.Greater(count, 1);
                System.Console.WriteLine("TestWithQueryOver returned {0} items", count);
            }
        }
        
        [Test]
        public void TestWithQueryOver([Values("WCPFC")] string entityName)
        {
            // NHibernate QueryOver articles
            // http://iamnotmyself.com/2010/08/16/nhibernate-3-0-queryover-syntax-is-the-bees-knees/
            // https://gist.github.com/davybrion/939649
            // http://www.google.com.au/search?q=nhibernate+joinalias&aq=f&oq=nhibernate+joinalias&sourceid=chrome&ie=UTF-8
            // http://stackoverflow.com/questions/12349504/define-join-condition-in-code
            // http://stackoverflow.com/search?q=%5Bnhibernate%5D+QueryOver
            Trip trip = null;
            IAccessControl ace = null;
            using (var session = TubsDataService.GetStatelessSession())
            {               
                var query = session.QueryOver<Trip>(() => trip)
                                   .JoinAlias(() => trip.AccessControl, () => ace, JoinType.InnerJoin)
                                   .Where(() => ace.EntityName == entityName);

                var trips = query.Take(5).List();
                var count = trips.Count;
                Assert.Greater(count, 1);
                System.Console.WriteLine("TestWithQueryOver returned {0} items", count);
            }
        }

        [Test]
        public void TestDetachedCriteriaEx([Values("WCPFC")] string entityName)
        {
            // Ayende's Rhino-Security uses DetachedCriteria
            // It's fairly old, so the approach might not actually be the best choice
            // for current versions of NHibernate
            // https://github.com/ayende/rhino-security/tree/master/Rhino.Security
            // http://www.sightsource.net/blog/nhibernate-detached-criteria
            var dc = DetachedCriteria.For<Trip>()
                                     .CreateAlias("AccessControl", "ace", JoinType.InnerJoin)
                                     .Add(Expression.Eq("ace.EntityName", entityName));

            var session = TubsDataService.GetStatelessSession();            
            using (var repo = TubsDataService.GetRepository<Trip>(session))
            {
                var criteria = dc.GetExecutableCriteria(session);
                var count = criteria.List<Trip>().Count;
                System.Console.WriteLine("DetachedCriteria returned {0} items", count);
            }

        }

        [Test]
        public void TestWithEmbeddedAcl([Values("WCPFC")] string entityName)
        {
            var session = TubsDataService.GetSession();
            // EnableFilter only works for stateful sessions
            //session.EnableFilter("foo");
            using (var repo = TubsDataService.GetRepository<Trip>(true))
            {
                var trips = repo.FilterBy(t => t.AccessControl.Where(a => a.EntityName == entityName).Any());
                var count = trips.Count();
                System.Console.WriteLine("EmbeddedAcl returned {0} items", count);
                Assert.Greater(count, 1);
            }

        }
    }
}
