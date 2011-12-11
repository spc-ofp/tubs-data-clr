// -----------------------------------------------------------------------
// <copyright file="VesselTest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class VesselTest : BaseTest
    {
        [Test]
        public void TestGetVesselList()
        {
            var vessels = Session.CreateCriteria(typeof(Vessel)).List<Vessel>();
            Assert.NotNull(vessels);
            Assert.Greater(vessels.Count, 0);
        }

        [Test]
        public void TestGetVessel()
        {
            var vessel = Session.Get<Vessel>(23382);
            Assert.NotNull(vessel);
            Assert.AreEqual("FONG SEONG 196", vessel.Name.Trim());
        }
    }
}
