﻿// -----------------------------------------------------------------------
// <copyright file="WellReconciliationTest.cs" company="">
// TODO: Update copyright text.
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
    using System.Linq;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class WellReconciliationTest : BaseTest
    {
        private IRepository<PurseSeineWellReconciliation> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = TubsDataService.GetRepository<PurseSeineWellReconciliation>(true);
        }
        
        [Test]
        public void GetSingleReconciliation([Values(2)] int reconId)
        {
            var recon = this.repo.FindById(reconId);
            Assert.NotNull(recon);
            Assert.AreEqual("0400", recon.ObserverTimeOnly);
            Assert.AreEqual(ActionType.WT, recon.ActionCode);
            Assert.AreEqual(-8.0m, recon.PortWell8);
            Assert.False(recon.PortWell9.HasValue);
        }

        [Test]
        public void GetReconciliationsByTripId([Values(69)] int tripId)
        {
            var recons = this.repo.FilterBy(r => r.Trip.Id == tripId);
            Assert.NotNull(recons);
            Assert.True(recons.Count() > 0);
        }

    }
}
