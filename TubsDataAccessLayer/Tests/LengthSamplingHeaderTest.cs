// -----------------------------------------------------------------------
// <copyright file="LengthSamplingHeaderTest.cs" company="Secretariat of the Pacific Community">
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
    public class LengthSamplingHeaderTest
    {
        private IRepository<LengthSamplingHeader> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = TubsDataService.GetRepository<LengthSamplingHeader>(false);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            this.repo.Dispose();
        }

        [Test]
        public void TestGetHeaderList()
        {
            var headers = this.repo.All().ToPagedList(1, 1000);
            Assert.NotNull(headers);
            Assert.Greater(headers.Count(), 100);
        }

        [Test]
        public void TestGetHeader()
        {
            var header = this.repo.FindById(72);
            Assert.NotNull(header);
            Assert.AreEqual(72, header.Id);
            Assert.NotNull(header.Set);
            Assert.AreEqual(83, header.Set.Id);
            Assert.AreEqual(9, header.TotalBrailCount);
            Assert.NotNull(header.Samples);
            Assert.Greater(header.Samples.Count, 90);
            Assert.NotNull(header.Brails);
            //// Although I picked this example because I know about how many samples it has, it's still good
            //// to confirm that the relationship really is correct.
            foreach (var sample in header.Samples)
            {
                Assert.NotNull(sample.Header);
                Assert.AreEqual(header.Id, sample.Header.Id);
            }
        }
    }
}
