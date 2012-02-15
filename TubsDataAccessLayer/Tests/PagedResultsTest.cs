// -----------------------------------------------------------------------
// <copyright file="PagedResultsTest.cs" company="">
// TODO: Update copyright text.
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
    public class PagedResultsTest : BaseTest
    {
        private TubsRepository<Port> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = new TubsRepository<Port>(TubsDataService.GetSession());
        }

        [Test]
        public void GetPagedResults()
        {
            const int PAGE_SIZE = 25;
            var pagedPorts = repo.GetPagedList(0, PAGE_SIZE);
            Assert.NotNull(pagedPorts);
            Assert.AreEqual(PAGE_SIZE, pagedPorts.Entities.Count);
            Assert.False(pagedPorts.HasPrevious);
            Assert.True(pagedPorts.HasNext);

            pagedPorts = repo.GetPagedList(PAGE_SIZE, PAGE_SIZE);
            Assert.NotNull(pagedPorts);
            Assert.True(pagedPorts.HasPrevious);
            Assert.True(pagedPorts.HasNext);
        }
    }
}
