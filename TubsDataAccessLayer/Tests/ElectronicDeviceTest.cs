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
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class ElectronicDeviceTest : BaseTest
    {
        private TubsRepository<ElectronicDevice> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = new TubsRepository<ElectronicDevice>(TubsDataService.GetSession());
        }

        [Test]
        public void TestGetElectronics()
        {
            var electronics = this.repo.FilterBy(x => x.Trip.Id == 70);
            Assert.NotNull(electronics);
            Assert.Greater(electronics.Count<ElectronicDevice>(), 5);
            foreach (var device in electronics)
            {
                Assert.NotNull(device);
                Assert.NotNull(device.DeviceType);
            }
        }
    }
}
