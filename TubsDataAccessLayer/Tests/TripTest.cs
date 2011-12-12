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
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class TripTest : BaseTest
    {
        private TubsRepository<Trip> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = new TubsRepository<Trip>(TubsDataService.GetSession());
        }
        
        [Test]
        public void TestGetTripList()
        {
            var trips = this.repo.All();
            Assert.NotNull(trips);
            Assert.Greater(trips.Count<Trip>(), 0);
            foreach (Trip t in trips)
            {
                Assert.NotNull(t);
                Assert.NotNull(t.Observer);
                Assert.NotNull(t.Vessel);
                Assert.AreEqual("PS", t.Vessel.TypeCode.Trim());
                Assert.NotNull(t.DeparturePort);
                Assert.NotNull(t.ReturnPort);
                Assert.False(String.IsNullOrEmpty(t.EnteredBy));
                Assert.True(t.EnteredDate.HasValue);
            }
        }

        [Test]
        public void TestGetTrip()
        {
            var trip = this.repo.FindBy(68);           
            Assert.NotNull(trip);
            Assert.IsInstanceOf<PurseSeineTrip>(trip);
            Assert.NotNull(trip.Observer);
            Assert.AreEqual("PBS", trip.Observer.StaffCode.Trim());
            Assert.AreEqual("96-02", trip.TripNumber.Trim());
            Assert.NotNull(((PurseSeineTrip)trip).SeaDays);
            Assert.Greater(((PurseSeineTrip)trip).SeaDays.Count, 10);
            foreach (var seaDay in ((PurseSeineTrip)trip).SeaDays)
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
    }
}
