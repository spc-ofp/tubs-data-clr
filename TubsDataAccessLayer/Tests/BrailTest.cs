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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class BrailTest : BaseTest
    {
        private TubsRepository<Brail> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = new TubsRepository<Brail>(TubsDataService.GetSession());
        }
        
        [Test]
        public void TestGetBrail()
        {
            var brail = this.repo.FindBy(265);
            Assert.NotNull(brail);
            Assert.AreEqual(234, brail.Header.Id);
            Assert.IsNotNullOrEmpty(brail.Comments);
            Assert.IsTrue(brail.LengthCode.HasValue);
            Assert.AreEqual(LengthCode.UF, brail.LengthCode.Value);
        }
    }
}
