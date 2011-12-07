// -----------------------------------------------------------------------
// <copyright file="TripMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// 
// This file is part of TUBS.
// 
//  TUBS is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// TUBS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Mapping for common trip data.
    /// </summary>
    public class TripMap : ClassMap<Trip>
    {
        public TripMap()
        {
            Table("[obsv].[trip]");
            Id(x => x.Id, "obstrip_id").GeneratedBy.Identity();
            Map(x => x.TripNumber, "tripno");
            Map(x => x.DepartureDate, "dep_dtime");
            Map(x => x.UtcDepartureDate, "utc_dep_dtime");
            Map(x => x.ReturnDate, "ret_dtime");

            References(x => x.Vessel).Column("vessel_id");
            References(x => x.Observer).Column("staff_code");
            References(x => x.DeparturePort).Column("dep_port");
            References(x => x.ReturnPort).Column("ret_port");

            DiscriminateSubClassesOnColumn<string>("gear_code");
        }
    }

    /// <summary>
    /// Mapping for purse seine specific data.
    /// </summary>
    public class PurseSeineTripMap : SubclassMap<PurseSeineTrip>
    {
        public PurseSeineTripMap()
        {
            DiscriminatorValue("S");
            HasMany(x => x.SeaDays).KeyColumn("obstrip_id");
        }
    }

    /// <summary>
    /// Mapping for long line specific data.
    /// </summary>
    public class LongLineTripMap : SubclassMap<LongLineTrip>
    {
        public LongLineTripMap()
        {
            DiscriminatorValue("L");
        }
    }
}
