// -----------------------------------------------------------------------
// <copyright file="PollutionEventTest.cs" company="Secretariat of the Pacific Community">
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
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class PollutionEventTest : BaseTest
    {
        private TubsRepository<PollutionEvent> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = new TubsRepository<PollutionEvent>(TubsDataService.GetSession());
        }

        [Test]
        public void TestGetPollutionEvent()
        {
            // Event is a reserved word
            var pevent = repo.FindBy(1);
            Assert.NotNull(pevent);
            Assert.NotNull(pevent.Trip);
            Assert.AreEqual(70, pevent.Trip.Id);
            Assert.NotNull(pevent.Details);
            Assert.GreaterOrEqual(4, pevent.Details.Count);
            foreach (var detail in pevent.Details)
            {
                Assert.NotNull(detail);
                Assert.NotNull(detail.Header);
                Assert.AreEqual(pevent, detail.Header);
                Assert.IsNotNullOrEmpty(detail.Quantity);
                Assert.IsNotNullOrEmpty(detail.Description);
            }
        }
    }
}
