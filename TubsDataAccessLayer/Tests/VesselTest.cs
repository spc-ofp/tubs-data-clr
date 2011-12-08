// -----------------------------------------------------------------------
// <copyright file="VesselTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// 
// This file is part of TUBS.
// 
//  TUBS is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// TUBS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class VesselTest : BaseTest
    {
        private TubsRepository<Vessel> repo;

        [TestFixtureSetUp]
        public void SetUp()
        {
            repo = new TubsRepository<Vessel>(TubsDataService.GetSession());
        }
        
        [Test]
        public void TestGetVesselList()
        {
            var vessels = repo.All();
            Assert.NotNull(vessels);
            Assert.Greater(vessels.Count<Vessel>(), 0);
        }

        [Test]
        public void TestGetVessel()
        {
            var vessel = repo.FindBy(23382);
            Assert.NotNull(vessel);
            Assert.AreEqual("FONG SEONG 196", vessel.Name.Trim());
        }
    }
}
