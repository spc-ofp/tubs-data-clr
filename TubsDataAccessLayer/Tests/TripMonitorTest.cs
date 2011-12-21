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
            var gen3s = repo.All();
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
            var gen3 = repo.FindBy(62);
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
    }
}
