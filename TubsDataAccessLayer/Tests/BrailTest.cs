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
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;
    using PagedList;

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
        public void GetBrail()
        {
            var brail = this.repo.FindById(265);
            Assert.NotNull(brail);
            Assert.AreEqual(234, brail.Header.Id);
            Assert.AreEqual(5, brail.Brail1FullnessCode);
            Assert.AreEqual(3, brail.SamplesFromBrail1);
        }

        [Test]
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
