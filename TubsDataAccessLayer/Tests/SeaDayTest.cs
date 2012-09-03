// -----------------------------------------------------------------------
// <copyright file="SeaDayTest.cs" company="Secretariat of the Pacific Community">
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
    public class SeaDayTest : BaseTest
    {
        [Test]
        public void TestGetSeaDay([Values(221)] int dayId)
        {
            using (var repo = TubsDataService.GetRepository<SeaDay>(false))
            {
                var seaday = repo.FindById(dayId) as PurseSeineSeaDay;
                Assert.NotNull(seaday);
                Assert.NotNull(seaday.Activities);
                Assert.Greater(seaday.Activities.Count, 5);
                foreach (var activity in seaday.Activities)
                {
                    Assert.NotNull(activity.Day);
                    Assert.AreEqual(seaday, activity.Day);
                }
            }
        }

        [Test]
        public void TestGetSeaDaysForTrip([Values(70)] int tripId)
        {
            using (var repo = TubsDataService.GetRepository<SeaDay>(true))
            {
                var seadays = repo.FilterBy(sd => sd.Trip.Id == tripId);
                Assert.NotNull(seadays);
                Assert.GreaterOrEqual(seadays.Count<SeaDay>(), 19);
                foreach (var seaday in seadays)
                {
                    Assert.IsInstanceOf<PurseSeineSeaDay>(seaday);
                }
            }
        }
    }
}
