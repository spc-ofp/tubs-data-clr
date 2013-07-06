// -----------------------------------------------------------------------
// <copyright file="ElectronicDeviceTest.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class ElectronicDeviceTest : BaseTest
    {
        [Test]
        public void GetElectronicsForTrip([Values(389)] int tripId)
        {
            using (var repo = TubsDataService.GetRepository<ElectronicDevice>(true))
            {
                var electronics = repo.FilterBy(x => x.Trip.Id == tripId);
                Assert.NotNull(electronics);
                Assert.AreEqual(21, electronics.Count());
                Assert.AreEqual(10, electronics.Where(e => e.DeviceType == Common.ElectronicDeviceType.Other).Count());
                foreach (var device in electronics)
                {
                    Assert.NotNull(device);
                    if (device.DeviceType != Common.ElectronicDeviceType.Other)
                    {
                        // Device with a "standard" category has no description
                        Assert.Null(device.Description);
                    }
                }

            }
        }

        /// <summary>
        /// Test electronics sorting functionality.
        /// </summary>
        /// <remarks>
        /// This trip was modified to create this test case.  There are two
        /// bird radar devices.  Originally, they were both marked as 'OIF'.
        /// The item with the higher device_id value was modified to 'ALL'.
        /// </remarks>
        /// <param name="tripId">trip primary key</param>
        [Test]
        public void SortElectronics([Values(398)] int tripId)
        {
            using (var repo = TubsDataService.GetRepository<Trip>(false))
            {
                var trip = repo.FindById(tripId);
                Assert.NotNull(trip);
                Assert.NotNull(trip.Electronics);
                Assert.Less(0, trip.Electronics.Count);
                trip.SortElectronics();
                var birdRadar = trip.Electronics.Where(e => e.DeviceType == Common.ElectronicDeviceType.BirdRadar).FirstOrDefault();
                Assert.NotNull(birdRadar);
                StringAssert.AreEqualIgnoringCase("FR-1460DS", birdRadar.Model);
            }
        }
    }
}
