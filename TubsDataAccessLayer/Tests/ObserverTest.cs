// -----------------------------------------------------------------------
// <copyright file="ObserverTest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Tubs.DAL.Tests
{
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
        
        [Test]
        public void TestGetObserverList()
        {

            var observers = Session.CreateCriteria(typeof(Observer)).List<Observer>();
            Assert.NotNull(observers);
            Assert.Greater(observers.Count, 0);
            var observer = observers.First<Observer>();
            Assert.NotNull(observer);
            Assert.False(String.IsNullOrEmpty(observer.StaffCode));
        }

        [Test]
        public void TestGetObserver()
        {
            var observer = Session.Get<Observer>("PBS");
            Assert.NotNull(observer);
            Assert.AreEqual("PBS", observer.StaffCode.Trim());
            Assert.NotNull(observer.Trips);
            Assert.Greater(observer.Trips.Count, 0);
        }
    }
}
