// -----------------------------------------------------------------------
// <copyright file="PurseSeineSetTest.cs" company="Secretariat of the Pacific Community">
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
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class PurseSeineSetTest : BaseTest
    {

        private TubsRepository<PurseSeineSet> repo;

        [TestFixtureSetUp]
        public void SetUp()
        {
            repo = new TubsRepository<PurseSeineSet>(TubsDataService.GetSession());
        }
        
        [Test]
        public void TestGetSet()
        {
            var set = repo.FindBy(277);
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
}
