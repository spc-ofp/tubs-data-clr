// -----------------------------------------------------------------------
// <copyright file="PageCountTest.cs" company="Secretariat of the Pacific Community">
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
    using NUnit.Framework;
    using PagedList;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class PageCountTest : BaseTest
    {
        [Test]
        public void AddPageCount([Values(70)] int tripId)
        {
            var session = TubsDataService.GetSession();
            var trepo = TubsDataService.GetRepository<Trip>(session);
            var repo = TubsDataService.GetRepository<PageCount>(session);

            var trip = trepo.FindById(tripId);

            var pc = new PageCount();
            pc.FormCount = 1;
            pc.FormName = Common.FormNames.GEN3;
            pc.EnteredBy = @"NOUMEA\coreyc";
            pc.EnteredDate = DateTime.Now;
            pc.Trip = trip;

            using (var xa = session.BeginTransaction())
            {
                repo.Save(pc);
                xa.Commit();
                repo.Reload(pc);
                Assert.NotNull(pc);
                Assert.AreNotEqual(0, pc.Id);
            }
        }
    }
}
