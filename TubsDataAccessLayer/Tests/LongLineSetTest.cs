﻿// -----------------------------------------------------------------------
// <copyright file="LongLineSetTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class LongLineSetTest
    {
        [Test]
        public void GetLongLineSet([Values(78,79)] int setId)
        {
            using (var repo = TubsDataService.GetRepository<LongLineSet>(true))
            {
                var set = repo.FindById(setId);
                Assert.NotNull(set);
                var baits = set.BaitSpecies;
                Assert.NotNull(baits);
                Assert.AreEqual(2, baits.Count());
                var baitString = String.Join(",", baits);
                StringAssert.AreEqualIgnoringCase("CLP,HER", baitString);
            }
        }

        [Test]
        public void GetSetWithMeasuringInstrument([Values(25, 26)] int setId)
        {
            using (var repo = TubsDataService.GetRepository<LongLineSet>(true))
            {
                var set = repo.FindById(setId);
                Assert.NotNull(set);
                Assert.True(set.MeasuringInstrument.HasValue);
                Assert.AreEqual(MeasuringInstrument.C, set.MeasuringInstrument);
            }
        }
    }
}
