// -----------------------------------------------------------------------
// <copyright file="MetricConversionTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Common;
    using System;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class MetricConversionTest
    {
        [Test]
        public void KnotsToMetersPerSecond()
        {
            decimal knots = 125.0m;
            decimal expected = 64.306m; // From Google calculator
            decimal actual = MetricConversions.KnotsToMetersPerSecond(knots);
            Assert.That(expected, Is.EqualTo(actual).Within(0.01));
        }

        [Test]
        public void MetersPerSecondToKnots()
        {
            decimal mps = 125.0m;
            decimal expected = 242.98m;
            decimal actual = MetricConversions.MetersPerSecondToKnots(mps);
            Assert.That(expected, Is.EqualTo(actual).Within(0.1));
        }

        [Test]
        public void ArbitraryUnitsToMeters()
        {
            
            decimal meters = 100.0m;
            // Identity transform
            decimal actual = MetricConversions.ConvertLengthToMeters(meters, UnitOfMeasure.Meters);
            Assert.That(meters, Is.EqualTo(actual).Within(0.01));

            actual = MetricConversions.ConvertLengthToMeters(0.1m, UnitOfMeasure.Kilometers);
            Assert.That(meters, Is.EqualTo(actual).Within(0.01));

            actual = MetricConversions.ConvertLengthToMeters(12, UnitOfMeasure.Inches);
            Assert.That(0.305m, Is.EqualTo(actual).Within(0.01)); // From Google calculator

            actual = MetricConversions.ConvertLengthToMeters(10, UnitOfMeasure.Centimeters);
            Assert.That(0.1m, Is.EqualTo(actual).Within(0.01));

            actual = MetricConversions.ConvertLengthToMeters(2, UnitOfMeasure.Fathoms);
            Assert.That(3.66m, Is.EqualTo(actual).Within(0.01)); // From Google calculator

            actual = MetricConversions.ConvertLengthToMeters(75, UnitOfMeasure.Yards);
            Assert.That(68.58m, Is.EqualTo(actual).Within(0.01)); // From Google calculator

            actual = MetricConversions.ConvertLengthToMeters(1.1m, UnitOfMeasure.NauticalMiles);
            Assert.That(2037.2m, Is.EqualTo(actual).Within(0.1)); // From Google calculator
        }

        [Test]
        public void ArbitraryUnitsFromMeters()
        {
            decimal meters = 100.0m;
            // Identity transform
            decimal actual = MetricConversions.ConvertLengthFromMeters(meters, UnitOfMeasure.Meters);
            Assert.That(meters, Is.EqualTo(actual).Within(0.01));

            actual = MetricConversions.ConvertLengthFromMeters(1500, UnitOfMeasure.Kilometers);
            Assert.That(1.5m, Is.EqualTo(actual).Within(0.01));

            actual = MetricConversions.ConvertLengthFromMeters(1.02m, UnitOfMeasure.Centimeters);
            Assert.That(102m, Is.EqualTo(actual).Within(0.01));

            actual = MetricConversions.ConvertLengthFromMeters(2.5m, UnitOfMeasure.Inches);
            Assert.That(98.425m, Is.EqualTo(actual).Within(0.01)); // From Google calculator

            actual = MetricConversions.ConvertLengthFromMeters(1.75m, UnitOfMeasure.Fathoms);
            Assert.That(0.957m, Is.EqualTo(actual).Within(0.01)); // From Google calculator

            actual = MetricConversions.ConvertLengthFromMeters(500m, UnitOfMeasure.NauticalMiles);
            Assert.That(0.270m, Is.EqualTo(actual).Within(0.01)); // From Google calculator

            actual = MetricConversions.ConvertLengthFromMeters(20m, UnitOfMeasure.Yards);
            Assert.That(21.87m, Is.EqualTo(actual).Within(0.01)); // From Google calculator
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void LengthToVelocity()
        {
            decimal actual = MetricConversions.ConvertLengthFromMeters(1500, UnitOfMeasure.MetersPerSecond);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VelocityToLength()
        {
            decimal actual = MetricConversions.ConvertLengthToMeters(1500, UnitOfMeasure.Knots);
        }
    }
}
