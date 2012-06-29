// -----------------------------------------------------------------------
// <copyright file="LongLineSetHaulEventTest.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class LongLineSetHaulEventTest
    {
        [Test]
        public void FixStartAndEnd()
        {
            // Use a known date for the start of the set
            var startOfSet = DateTime.Now;
            var events = new List<LongLineSetHaulEvent>()
            {
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet.AddMinutes(5)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(10)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(15)
                }
            };

            LongLineSetHaulEvent.SetStartAndEnd(events);
            Assert.AreEqual(0, events.Where(e => !e.ActivityType.HasValue).Count());
            Assert.AreEqual(startOfSet, events.Where(e => HaulActivityType.StartOfSet.Equals(e.ActivityType)).First().LogDate.Value);
        }

        [Test]
        public void FixStartAndEndForShuffledEvents()
        {
            // Use a known date for the start of the set
            var startOfSet = DateTime.Now;
            var events = new List<LongLineSetHaulEvent>()
            {
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(10)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet.AddMinutes(5)
                },                
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(15)
                }
            };

            LongLineSetHaulEvent.SetStartAndEnd(events);
            Assert.AreEqual(0, events.Where(e => !e.ActivityType.HasValue).Count());
            Assert.AreEqual(startOfSet, events.Where(e => HaulActivityType.StartOfSet.Equals(e.ActivityType)).First().LogDate.Value);
        }

        [Test]
        public void FixStartAndEndWithNullEvent()
        {
            // Use a known date for the start of the set
            var startOfSet = DateTime.Now;
            var events = new List<LongLineSetHaulEvent>()
            {
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet
                },
                null,
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(10)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet.AddMinutes(5)
                },                
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(15)
                }
            };

            LongLineSetHaulEvent.SetStartAndEnd(events);
            Assert.AreEqual(0, events.Where(e => e != null && !e.ActivityType.HasValue).Count());
            Assert.AreEqual(startOfSet, events.Where(e => HaulActivityType.StartOfSet.Equals(e.ActivityType)).First().LogDate.Value);
        }

        [Test]
        public void FixStartAndEndForLargeNumberOfHaulEvents()
        {
            // Use a known date for the start of the set
            var startOfSet = DateTime.Now;
            var endOfHaul = DateTime.Now.AddMinutes(40);
            var events = new List<LongLineSetHaulEvent>()
            {
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet.AddMinutes(5)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(10)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(15)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(20)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(25)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(30)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(35)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = endOfHaul
                }
            };

            LongLineSetHaulEvent.SetStartAndEnd(events);
            Assert.AreEqual(5, events.Where(e => !e.ActivityType.HasValue).Count());
            Assert.AreEqual(startOfSet, events.Where(e => HaulActivityType.StartOfSet.Equals(e.ActivityType)).First().LogDate.Value);
            Assert.AreEqual(endOfHaul, events.Where(e => HaulActivityType.EndOfHaul.Equals(e.ActivityType)).First().LogDate.Value);
        }

        [Test]
        public void FixStartAndEndWithNullDate()
        {
            // Use a known date for the start of the set
            var startOfSet = DateTime.Now;
            var events = new List<LongLineSetHaulEvent>()
            {
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S"
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(10)
                },
                new LongLineSetHaulEvent()
                {
                    Sethaul = "S",
                    LogDate = startOfSet.AddMinutes(5)
                },                
                new LongLineSetHaulEvent()
                {
                    Sethaul = "H",
                    LogDate = startOfSet.AddMinutes(15)
                }
            };

            LongLineSetHaulEvent.SetStartAndEnd(events);
            // The second item in the array won't have an ActivityType
            Assert.AreEqual(1, events.Where(e => e != null && !e.ActivityType.HasValue).Count());
            Assert.AreEqual(startOfSet, events.Where(e => HaulActivityType.StartOfSet.Equals(e.ActivityType)).First().LogDate.Value);
        }
    }
}
