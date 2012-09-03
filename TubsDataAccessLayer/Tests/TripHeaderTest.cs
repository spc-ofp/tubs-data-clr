// -----------------------------------------------------------------------
// <copyright file="TripHeaderTest.cs" company="Secretariat of the Pacific Community">
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
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class TripHeaderTest
    {
        [Test]
        public void GetAllTripHeaders()
        {
            using (var repo = TubsDataService.GetRepository<TripHeader>(true))
            {
                var headers = repo.All();
                Assert.NotNull(headers);
                foreach (var header in headers)
                {
                    Assert.NotNull(header);
                    Assert.False(String.IsNullOrEmpty(header.StaffCode));
                    Assert.False(String.IsNullOrEmpty(header.ProgramCode));
                    Assert.False(String.IsNullOrEmpty(header.SpcTripNumber));
                }
            }
        }
    }
}
