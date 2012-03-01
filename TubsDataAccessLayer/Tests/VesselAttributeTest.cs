// -----------------------------------------------------------------------
// <copyright file="VesselAttributeTest.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;
    using NHibernate;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class VesselAttributeTest
    {
        private ISession session;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.session = TubsDataService.GetSession();
        }

        [Test]
        public void ModifyVesselAttributes()
        {
            var transaction = this.session.BeginTransaction();
            var trip = new TubsRepository<Trip>(this.session).FindBy(103) as PurseSeineTrip;
            Assert.NotNull(trip);
            var attributes = trip.VesselAttributes;
            Assert.NotNull(attributes);
            attributes.HelicopterMake = "Hughes";
            attributes.HelicopterModel = "MD 500 Defender";
            var repo = new TubsRepository<PurseSeineVesselAttributes>(this.session);
            repo.Update(attributes);
            transaction.Commit();

        }
    }
}
