// -----------------------------------------------------------------------
// <copyright file="Gen5Test.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class Gen5Test : BaseTest
    {
        [Test]
        public void GetFad([Values(1)] int fadId)
        {
            using (var repo = TubsDataService.GetRepository<Gen5Object>(false))
            {
                var fad = repo.FindById(fadId);
                Assert.NotNull(fad);
                Assert.NotNull(fad.Activity);
                Assert.AreEqual(3718, fad.Activity.Id);
                Assert.True(fad.ObjectNumber.HasValue);
                Assert.AreEqual(1, fad.ObjectNumber.Value);
                Assert.True(fad.Origin.HasValue);
                Assert.AreEqual(FadOrigin.DeployedPreviousTrip, fad.Origin.Value);
                Assert.True(fad.IsSsiTrapped.HasValue);
                Assert.False(fad.IsSsiTrapped.Value);
            }
        }

        [Test]
        public void SaveFad()
        {
            
            var session = TubsDataService.GetSession();
            var arepo = TubsDataService.GetRepository<Activity>(session);
            var frepo = TubsDataService.GetRepository<Gen5Object>(session);

            var fad = new Gen5Object();
            fad.ObjectNumber = 1;
            fad.Activity = arepo.FindById(1976) as PurseSeineActivity;
            Assert.NotNull(fad.Activity);
            fad.Comments = "Test FAD";
            fad.Origin = FadOrigin.DeployedThisTrip;
            fad.Materials.Add(
                new Gen5Material
                { 
                    IsAttachment = false,
                    Fad = fad,
                    Material = FadMaterials.CoconutFronds
                });

            using (var xa = session.BeginTransaction())
            {
                frepo.Add(fad);
                xa.Commit();
                frepo.Reload(fad);
                Assert.NotNull(fad);
                Assert.AreNotEqual(0, fad.Id);
            }
        }
    }
}
