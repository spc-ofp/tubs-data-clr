// -----------------------------------------------------------------------
// <copyright file="DateExtensionTest.cs" company="Secretariat of the Pacific Community">
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
    public class DateExtensionTest
    {
        [Test]
        public void NullDate()
        {
            DateTime? dt = null;
            DateTime? result = dt.Merge("1830");
            Assert.False(result.HasValue);
        }

        [Test]
        public void MissingNullableTime()
        {
            DateTime? dt = new DateTime(2009, 2, 12);
            DateTime? result = dt.Merge(null);
            Assert.True(result.HasValue);
            Assert.AreEqual(0, result.Value.CompareTo(dt.Value));
            result = dt.Merge(string.Empty);
            Assert.True(result.HasValue);
            Assert.AreEqual(0, result.Value.CompareTo(dt.Value));
        }

        [Test]
        public void MissingTime()
        {
            DateTime dt = new DateTime(2010, 3, 30);
            DateTime result = dt.Merge(null);
            Assert.AreEqual(0, result.CompareTo(dt));
            result = dt.Merge(string.Empty);
            Assert.AreEqual(0, result.CompareTo(dt));
        }

        [Test]
        public void InvalidNullableTime()
        {
            DateTime? dt = new DateTime(2009, 2, 12);
            DateTime? result = dt.Merge("123");
            Assert.True(result.HasValue);
            Assert.AreEqual(0, result.Value.CompareTo(dt.Value));
            result = dt.Merge("12345");
            Assert.True(result.HasValue);
            Assert.AreEqual(0, result.Value.CompareTo(dt.Value));
        }

        [Test]
        public void InvalidTime()
        {
            DateTime dt = new DateTime(2009, 2, 12);
            DateTime result = dt.Merge("123");
            Assert.AreEqual(0, result.CompareTo(dt));
            result = dt.Merge("12345");
            Assert.AreEqual(0, result.CompareTo(dt));
        }

        [Test]
        public void ValidNullableTime()
        {
            DateTime? dt = new DateTime(2009, 2, 12);
            DateTime? result = dt.Merge("1830");
            Assert.True(result.HasValue);
            Assert.AreEqual(1, result.Value.CompareTo(dt.Value));
        }

        [Test]
        public void ValidTime()
        {
            DateTime dt = new DateTime(2011, 8, 17);
            DateTime result = dt.Merge("1830");
            Assert.AreEqual(1, result.CompareTo(dt));
        }

        [Test]
        public void ValidDates()
        {
            var result = "30/03/10".Parse();
            Assert.True(result.HasValue);            
            Assert.AreEqual(30, result.Value.Day);
            Assert.AreEqual(3, result.Value.Month);
            Assert.AreEqual(2010, result.Value.Year);
        }

        [Test]
        public void InvalidDates()
        {
            var result = "03/30/10".Parse();
            Assert.False(result.HasValue);
        }
    }
}
