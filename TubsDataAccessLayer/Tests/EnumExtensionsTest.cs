// -----------------------------------------------------------------------
// <copyright file="EnumExtensionsTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class EnumExtensionsTest
    {
        [Test]
        public void NonNullableEnumeration()
        {
            SeaCode sc = SeaCode.C;
            Assert.AreEqual("Calm", sc.GetDescription());
        }

        [Test]
        public void NullableEnumeration()
        {
            DetectionMethod? dm = null;
            Assert.AreEqual(String.Empty, dm.GetDescription());

            // Change detection method to a real value
            dm = DetectionMethod.Anchored;
            Assert.AreEqual("Anchored FAD/payao (recorded)", dm.GetDescription());
        }

        [Test]
        public void VelocityCheck()
        {
            UnitOfMeasure knots = UnitOfMeasure.Knots;
            UnitOfMeasure mps = UnitOfMeasure.MetersPerSecond;
            UnitOfMeasure klicks = UnitOfMeasure.Kilometers;
            Assert.True(knots.IsVelocity());
            Assert.True(mps.IsVelocity());
            Assert.False(klicks.IsVelocity());
        }
    }
}
