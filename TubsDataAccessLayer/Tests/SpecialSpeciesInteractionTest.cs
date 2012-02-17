// -----------------------------------------------------------------------
// <copyright file="SpecialSpeciesInteractionTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
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
    public class SpecialSpeciesInteractionTest : BaseTest
    {
        private TubsRepository<SpecialSpeciesInteraction> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = new TubsRepository<SpecialSpeciesInteraction>(TubsDataService.GetSession());
        }

        [Test]
        public void GetInteraction()
        {
            var interaction = repo.FindBy(7);
            Assert.NotNull(interaction);
            Assert.AreEqual("1235", interaction.LandedTimeOnly);
            Assert.True(interaction.LandedDateOnly.HasValue);
            Assert.AreEqual(TimeSpan.Zero, interaction.LandedDateOnly.Value.TimeOfDay);
            Assert.AreEqual(8, interaction.SightingCount);
            Assert.AreEqual(70.0, interaction.SightingDistance);
        }
    }
}
