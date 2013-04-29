// -----------------------------------------------------------------------
// <copyright file="InteractionTest.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class InteractionTest : BaseTest
    {
        [Test]
        public void GetInteractionsForTrip([Values(103)] int tripId)
        {
            // Load the trip and see what's on there
            using (var repo = TubsDataService.GetRepository<Trip>(false))
            {
                var trip = repo.FindById(tripId);
                Assert.NotNull(trip);
                Assert.NotNull(trip.Interactions);
                Assert.GreaterOrEqual(trip.Interactions.Count, 4);
            }
            
            using (var repo = TubsDataService.GetRepository<Interaction>(false))
            {
                var interactions = repo.FilterBy(i => i.Trip.Id == tripId).ToList();
                Assert.NotNull(interactions);
                Assert.GreaterOrEqual(interactions.Count, 4);
            }
        }
        
        [Test]
        public void GetSighting([Values(7)] int interactionId)
        {
            using (var repo = TubsDataService.GetRepository<Interaction>(true))
            {
                var interaction = repo.FindById(interactionId);
                Assert.NotNull(interaction);               
                Assert.AreEqual("1235", interaction.LandedTimeOnly);
                Assert.True(interaction.LandedDateOnly.HasValue);
                Assert.AreEqual(TimeSpan.Zero, interaction.LandedDateOnly.Value.TimeOfDay);
                var sighting = interaction as SightingInteraction;
                Assert.NotNull(sighting);
                Assert.AreEqual(8, sighting.SightingCount);
                Assert.AreEqual(70.0, sighting.SightingDistance);
            }
        }

        [Test]
        public void GetLanding([Values(10)] int interactionId)
        {
            using (var repo = TubsDataService.GetRepository<Interaction>(true))
            {
                var interaction = repo.FindById(interactionId);
                Assert.NotNull(interaction);
                // RHN, A0
                var landing = interaction as LandedInteraction;
                Assert.NotNull(landing);
                StringAssert.AreEqualIgnoringCase("RHN", landing.SpeciesCode);
                Assert.True(landing.LandedConditionCode.HasValue);
                Assert.AreEqual(Common.ConditionCode.A0, landing.LandedConditionCode);
            }
        }
    }
}
