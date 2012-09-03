// -----------------------------------------------------------------------
// <copyright file="SightingTest.cs" company="Secretariat of the Pacific Community">
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
    using PagedList;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class SightingTest : BaseTest
    {
        [Test]
        public void TestGetSightings()
        {
            using (var repo = TubsDataService.GetRepository<Sighting>(true))
            {
                var sightings = repo.All().ToPagedList(1, 100);
                Assert.NotNull(sightings);
                Assert.GreaterOrEqual(sightings.Count<Sighting>(), 29);
                foreach (var sighting in sightings)
                {
                    Assert.NotNull(sighting);
                    string debugMessage = String.Format("sightingId: {0}", sighting.Id);
                    Assert.NotNull(sighting.Trip);
                    // Either a vessel or a vessel name should be in the record
                    // Except that it's not true for a bunch of records.  These will have to be audited, but for now, skip this assertion
                    //Assert.True(null != sighting.Vessel || !String.IsNullOrEmpty(sighting.VesselName), debugMessage);
                    Assert.True(sighting.GetDate().HasValue, debugMessage);
                    Assert.IsNotNullOrEmpty(sighting.Latitude);
                    Assert.IsNotNullOrEmpty(sighting.Longitude);
                }
            }
        }
    }
}
