// -----------------------------------------------------------------------
// <copyright file="PushpinMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
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
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Fluent NHibernate mapper for trip positions.
    /// </summary>
    public class PushpinMap : ClassMap<Pushpin>
    {
        public PushpinMap()
        {
            ReadOnly(); // It's sourced from a view
            Schema("obsv");
            // Purse seine and longline only.  Pole and line is still pending.
            Table("vw_positions");
            CompositeId().KeyProperty(x => x.FormName, "form_name").KeyProperty(x => x.EventKey, "event_key");
            Map(x => x.Latitude, "lat").Precision(8).Scale(4);
            Map(x => x.Longitude, "lon").Precision(8).Scale(4);
            Map(x => x.Timestamp, "tstamp");
            Map(x => x.Description, "event_description");

            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
