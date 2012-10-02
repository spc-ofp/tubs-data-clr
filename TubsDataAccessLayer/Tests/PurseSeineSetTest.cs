// -----------------------------------------------------------------------
// <copyright file="PurseSeineSetTest.cs" company="Secretariat of the Pacific Community">
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
    public class PurseSeineSetTest : BaseTest
    {   
        [Test]
        public void TestGetSet([Values(277)] int setId)
        {
            using (var repo = TubsDataService.GetRepository<PurseSeineSet>(false))
            {
                var set = repo.FindById(setId);
                Assert.NotNull(set);
                Assert.True(set.StartOfSetFromLog.HasValue);
                Assert.True(set.SkiffOff.HasValue);
                Assert.True(set.WinchOn.HasValue);
                Assert.True(set.RingsUp.HasValue);
                Assert.True(set.BeginBrailing.HasValue);
                Assert.True(set.EndBrailing.HasValue);
                Assert.NotNull(set.CatchList);
                Assert.Greater(set.CatchList.Count, 10);
                foreach (var setcatch in set.CatchList)
                {
                    Assert.AreEqual(set, setcatch.FishingSet);
                    Assert.NotNull(setcatch);
                    Assert.NotNull(setcatch.SpeciesCode);
                    Assert.NotNull(setcatch.FateCode);
                    Assert.NotNull(setcatch.ConditionCode);
                    Assert.True(setcatch.MetricTonsObserved.HasValue);
                    Assert.True(setcatch.MetricTonsFromLog.HasValue);
                }
            }
        }

        [Test]
        public void TestSetNumbers([Values(70)] int tripId)
        {
            using (var repo = TubsDataService.GetRepository<PurseSeineSet>(true))
            {
                var sets = repo.FilterBy(fs => fs.Activity.Day.Trip.Id == tripId);
                Assert.NotNull(sets);
                Assert.Greater(sets.Count(), 1);
                var maxSetDate = sets.Select(fs => fs.SkiffOff).Max();
                Assert.True(maxSetDate.HasValue);
                // This date is after the last set of the trip (by inspection)
                DateTime endDate = new DateTime(2010, 8, 29, 11, 20, 0);
                Assert.AreEqual(-1, maxSetDate.Value.CompareTo(endDate));

                // This date is between set 5 and set 6
                DateTime middleDate = new DateTime(2010, 8, 17, 10, 20, 0);
            }
        }
    }
}
