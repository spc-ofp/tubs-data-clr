// -----------------------------------------------------------------------
// <copyright file="ObserverTest.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// Unit tests for Observer
    /// </summary>
    [TestFixture]
    public class ObserverTest : BaseTest
    {
        private TubsRepository<Observer> repo;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.repo = new TubsRepository<Observer>(TubsDataService.GetSession());
        }
                
        [Test]
        public void TestGetObserverList()
        {
            var observers = this.repo.All();
            Assert.NotNull(observers);
            Assert.Greater(observers.Count<Observer>(), 0);
            var observer = observers.First<Observer>();
            Assert.NotNull(observer);
            Assert.False(String.IsNullOrEmpty(observer.StaffCode));
        }

        [Test]
        public void TestGetObserver()
        {
            var observer = this.repo.FindBy("PBS");
            Assert.NotNull(observer);
            Assert.AreEqual("PBS", observer.StaffCode.Trim());
            Assert.AreEqual("PETER SHARPLES (PBS)", observer.ToString());
            Assert.NotNull(observer.Trips);
            Assert.Greater(observer.Trips.Count, 0);
        }
    }
}
