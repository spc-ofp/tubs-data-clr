// -----------------------------------------------------------------------
// <copyright file="PushpinTest.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;
    using NHibernate;
    using NHibernate.Transform;
    using NUnit.Framework;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class PushpinTest
    {
        [Test]
        public void GetPushpins()
        {
            /*
            using (ISession session = TubsDataService.GetSession())
            {
                var query = session.CreateSQLQuery(Pushpin.FindByTrip);
                query.SetParameter(0, 70);
                query.SetResultTransformer(Transformers.AliasToBean<Pushpin>());

                IList<Pushpin> pins = query.List<Pushpin>();
                Assert.NotNull(pins);
                Assert.True(pins.Count > 200);
                foreach (var pin in pins)
                {
                    Assert.NotNull(pin);
                    Assert.True(pin.Timestamp.HasValue);
                    Assert.False(String.IsNullOrEmpty(pin.Description));
                }
            }
            */
        }
    }
}
