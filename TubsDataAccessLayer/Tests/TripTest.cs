// -----------------------------------------------------------------------
// <copyright file="TripTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
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
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;
    using PagedList;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class TripTest
    {
        private IRepository<Trip> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = TubsDataService.GetRepository<Trip>(false);
        }
        
        [Test]
        public void GetTripList()
        {
            // The stateless repo is okay for pulling in an entity and any top-level references
            // It doesn't work for lazy loading any collections, although there's a workaround with
            // .All().Where(...).FetchMany(...);
            // NOTE:  FetchMany has to come last!
            using (var statelessRepo = TubsDataService.GetRepository<Trip>(true))
            {
                var trips = statelessRepo.All().ToPagedList(1, 50);
                //var trips = this.repo.GetPagedList(0, 50).Entities;
                Assert.NotNull(trips);
                Assert.Greater(trips.Count(), 0);
                foreach (Trip t in trips)
                {
                    Assert.NotNull(t);
                    Assert.NotNull(t.Observer);
                    Assert.NotNull(t.Vessel);
                    //Assert.AreEqual(VesselTypeCode.PS, t.Vessel.TypeCode);
                    Assert.NotNull(t.DeparturePort);
                    Assert.NotNull(t.ReturnPort);
                    Assert.False(String.IsNullOrEmpty(t.EnteredBy));
                    Assert.True(t.EnteredDate.HasValue);
                }
            }
        }

        [Test]
        public void GetTripEx([Values(70)] int tripId)
        {
            var trip = this.repo.FindById(tripId) as PurseSeineTrip;
            Assert.IsNotNull(trip);
            Assert.True(trip.Version.HasValue);
            Assert.AreEqual(WorkbookVersion.v2007, trip.Version.Value);
            Assert.AreEqual("N/A", trip.AlternateTripNumber);
            Assert.NotNull(trip.Observer);
            Assert.NotNull(trip.CommunicationServices);
            Assert.NotNull(trip.Gear);
            Assert.AreEqual("FUKUOKA", trip.Gear.PowerblockMake);
            Assert.NotNull(trip.VesselAttributes);
            Assert.AreEqual(3, trip.VesselAttributes.SpeedboatCount);
            Assert.NotNull(trip.WellContent);
            Assert.True(trip.WellContent.Count > 4);
            Assert.NotNull(trip.MultiLandingInteractions);
            Assert.NotNull(trip.Interactions);
            Assert.True(1 == trip.Interactions.Count);
            Assert.NotNull(trip.Interactions[0]);
            Assert.AreEqual(2, trip.CommunicationServices.Id);
            var qry = from d in trip.SeaDays
                      from a in d.Activities
                      where a.ActivityType.HasValue && a.ActivityType.Value == Common.ActivityType.Fishing
                      select 1;
            Assert.GreaterOrEqual(qry.Sum(), 2);
            System.Console.WriteLine("Set Count: " + qry.Sum());
            Assert.IsNotNull(trip.Pushpins);
            Assert.True(trip.Pushpins.Count > 100);
        }

        [Test]
        public void GetPurseSeineTrip([Values(68)] int tripId)
        {
            var trip = this.repo.FindById(tripId) as PurseSeineTrip;      
            Assert.NotNull(trip);
            Assert.NotNull(trip.Observer);
            Assert.AreEqual("PBS", trip.Observer.StaffCode.Trim());
            Assert.AreEqual("96-02", trip.TripNumber.Trim());
            Assert.NotNull(trip.SeaDays);
            Assert.Greater(trip.SeaDays.Count, 10);
            foreach (var seaDay in trip.SeaDays)
            {
                Assert.NotNull(seaDay);
                Assert.NotNull(seaDay.Activities);
                Assert.Greater(seaDay.Activities.Count, 0);
                foreach (var activity in seaDay.Activities)
                {
                    Assert.NotNull(activity);
                }
            }
        }

        // 4321, and 4320 are NCOB longline trips
        [Test]
        public void GetLongLineTrip([Values(4321, 4320)] int tripId)
        {
            var trip = this.repo.FindById(tripId) as LongLineTrip;
            Assert.NotNull(trip);
            Assert.NotNull(trip.Observer);
            Assert.NotNull(trip.Vessel);
            Assert.NotNull(trip.FishingSets);
            Assert.True(trip.FishingSets.Count > 0);
        }

        [Test]
        public void GetTripWithObserver([Values(69)] int tripId)
        {
            using (var statelessRepo = TubsDataService.GetRepository<Trip>(true))
            {
                var trip = statelessRepo.FindById(tripId) as PurseSeineTrip;
                Assert.NotNull(trip);
                Assert.NotNull(trip.Observer);
            }
        }

        [Test]
        public void GetMyTrips()
        {
            using (var statelessRepo = TubsDataService.GetRepository<Trip>(true))
            {
                var trips = statelessRepo.FilterBy(t => t.EnteredBy.ToUpper().Contains("COREY"));
                Assert.NotNull(trips);
                Assert.True(trips.Count() > 5);
            }
        }
    }
}
