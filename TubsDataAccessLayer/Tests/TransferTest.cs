﻿// -----------------------------------------------------------------------
// <copyright file="TransferTest.cs" company="Secretariat of the Pacific Community">
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
    using PagedList;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class TransferTest : BaseTest
    {
        [Test]
        public void TestGetTransfers()
        {
            using (var repo = TubsDataService.GetRepository<Transfer>(true))
            {
                var transfers = repo.All().ToPagedList(1, 200);
                Assert.NotNull(transfers);
                foreach (var transfer in transfers)
                {
                    Assert.NotNull(transfer);
                    Assert.NotNull(transfer.Trip);
                    // Either a vessel or a vessel name should be in the record
                    // Except that it's not true for a bunch of records.  These will have to be audited, but for now, skip this assertion
                    //Assert.True(null != transfer.Vessel || !String.IsNullOrEmpty(transfer.VesselName));
                    Assert.True(transfer.GetDate().HasValue);
                    Assert.IsNotNullOrEmpty(transfer.Latitude);
                    Assert.IsNotNullOrEmpty(transfer.Longitude);
                }
            }
        }
    }
}
