// -----------------------------------------------------------------------
// <copyright file="TripMonitorTest.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;
    using System;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TripMonitorTest : BaseTest
    {
        private TubsRepository<TripMonitor> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = new TubsRepository<TripMonitor>(TubsDataService.GetSession());
        }

        public void TestGetTripMonitorList()
        {
            var gen3s = this.repo.All();
            Assert.NotNull(gen3s);
            Assert.GreaterOrEqual(10, gen3s.Count<TripMonitor>());
            foreach (var gen3 in gen3s)
            {
                Assert.NotNull(gen3);
                Assert.NotNull(gen3.Trip);
                Assert.NotNull(gen3.Details); // Can be empty, but shouldn't be null
            }
        }

        [Test]
        public void TestGetTripMonitor()
        {
            var gen3 = this.repo.FindBy(62);
            Assert.NotNull(gen3);
            Assert.NotNull(gen3.Trip);
            Assert.AreEqual(70, gen3.Trip.Id);
            Assert.NotNull(gen3.Details);
            Assert.AreEqual(3, gen3.Details.Count);
            foreach (var detail in gen3.Details)
            {
                Assert.NotNull(detail);
                Assert.AreEqual(gen3, detail.Header);
                Assert.AreEqual(gen3.Id, detail.Header.Id);
                Assert.IsNotNullOrEmpty(detail.Comments);
                Assert.IsTrue(detail.DetailDate.HasValue);

            }
        }

        [Test]
        public void AddTripMonitor()
        {
            const string userName = "Abraham Lincoln";
            DateTime enteredDate = DateTime.Now;

            int headerId = default(int);

            using (var session = TubsDataService.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // Find the first trip for which Dave J. Burgess is the observer
                    var trip = new TubsRepository<Trip>(session).FilterBy(t => t.Observer.StaffCode == "DJB").FirstOrDefault();
                    Assert.NotNull(trip);

                    // Create new, empty, GEN-3
                    var header = new TripMonitor();
                    header.Question1 = false;
                    header.EnteredBy = userName;
                    header.EnteredDate = enteredDate;
                    header.Trip = trip;

                    // Add a child record
                    var detail = new TripMonitorDetail();
                    detail.DetailDate = trip.DepartureDate.HasValue ? trip.DepartureDate.Value : trip.DepartureDateOnly.Value;
                    detail.Comments = "Xyzzy";
                    detail.EnteredBy = userName;
                    detail.EnteredDate = enteredDate;

                    header.AddDetail(detail);

                    Assert.True(new TubsRepository<TripMonitor>(session).Add(header));
                    headerId = header.Id;
                    Assert.False(default(int) == header.Id);
                    transaction.Commit();
                }
            }

            // Delete the entity afterwards
            using (var session = TubsDataService.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var repo = new TubsRepository<TripMonitor>(session);
                    var header = repo.FindBy(headerId);
                    Assert.NotNull(header);
                    Assert.NotNull(header.Trip);
                    Assert.NotNull(header.Details);
                    Assert.True(header.Question1.HasValue);
                    Assert.False(header.Question1.Value);
                    var child = header.Details[0];
                    Assert.NotNull(child);
                    Assert.AreEqual(userName, child.EnteredBy);
                    Assert.True(repo.Delete(header));
                    transaction.Commit();
                }
            }

        }
    }
}
