// -----------------------------------------------------------------------
// <copyright file="BrailTest.cs" company="Secretariat of the Pacific Community">
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
    using PagedList;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class BrailTest
    {
        private IRepository<Brail> repo;

        /// <summary>
        /// Create repository for use by all test cases.
        /// </summary>
        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = TubsDataService.GetRepository<Brail>(true);
        }
        
        [Test]
        public void GetBrail([Values(265)] int brailId)
        {
            var brail = this.repo.FindById(brailId);
            Assert.NotNull(brail);
            Assert.AreEqual(234, brail.Header.Id);
            Assert.AreEqual(1, brail.Record1.Sequence);
            Assert.AreEqual(5, brail.Record1.Fullness);
            Assert.AreEqual(3, brail.Record1.Samples);
        }

        [Test]
        public void TestBrailIndexedProperties([Values(265)] int brailId)
        {
            var brail = this.repo.FindById(brailId);
            Assert.NotNull(brail);
            var record = new BrailRecord()
            {
                Sequence = 20,
                Samples = 99,
                Fullness = 1
            };
            brail[19] = record;
            Assert.AreEqual(20, brail.Record20.Sequence);
            Assert.AreEqual(99, brail.Record20.Samples);
            Assert.AreEqual(1, brail.Record20.Fullness);
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexedPropertyException()
        {
            var brail = new Brail();
            var record = new BrailRecord();
            brail[30] = record;
        }

        [Test]
        [Ignore("Not worth doing")]
        public void GetBrails()
        {
            var brails = repo.All().ToPagedList(1, 1000);
            Assert.NotNull(brails);
            foreach (var brail in brails)
            {
                Assert.NotNull(brail);
            }
        }
    }
}
