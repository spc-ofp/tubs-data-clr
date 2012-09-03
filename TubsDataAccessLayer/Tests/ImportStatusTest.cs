// -----------------------------------------------------------------------
// <copyright file="ImportStatusTest.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class ImportStatusTest
    {
        private IRepository<ImportStatus> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = TubsDataService.GetRepository<ImportStatus>(true);
        }
        
        [Test]
        public void GetAllImports()
        {
            var imports = this.repo.All();
            Assert.NotNull(imports);
            foreach (ImportStatus import in imports)
            {
                Assert.NotNull(import);
                Assert.False(String.IsNullOrEmpty(import.SourceId));
                Assert.False(String.IsNullOrEmpty(import.SourceName));
            }
        }

        [Test]
        public void GetImport([Values(2222)] int importId)
        {
            var import = this.repo.FindById(importId);
            Assert.NotNull(import);
            Assert.AreEqual("FoxPro Observer", import.SourceName);
            Assert.AreEqual("50", import.SourceId);
            Assert.AreEqual(81, import.TripId);
            Assert.AreEqual("TubsTripProcessor", import.EnteredBy);
        }
    }
}
