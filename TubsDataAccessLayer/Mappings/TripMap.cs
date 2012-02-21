﻿// -----------------------------------------------------------------------
// <copyright file="TripMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
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
    /// Mapping for common trip data.
    /// </summary>
    public class TripMap : ClassMap<Entities.Trip>
    {
        public TripMap()
        {
            Table("obsv.trip");
            Id(x => x.Id, "obstrip_id").GeneratedBy.Identity();
            Map(x => x.TripNumber, "tripno");
            Map(x => x.DepartureDate, "dep_dtime");
            Map(x => x.DepartureDateOnly, "dep_date");
            Map(x => x.DepartureTimeOnly, "dep_time");
            Map(x => x.UtcDepartureDate, "utc_dep_dtime");
            Map(x => x.ReturnDate, "ret_dtime");
            Map(x => x.ReturnDateOnly, "ret_date");
            Map(x => x.ReturnTimeOnly, "ret_time");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.ProgramCode, "obsprg_code");
            Map(x => x.CountryCode, "country_code");
            Map(x => x.Version, "versn_id").CustomType(typeof(WorkbookVersion));

            References(x => x.Vessel).Column("vessel_id");
            References(x => x.Observer).Column("staff_code");
            References(x => x.DeparturePort).Column("dep_port");
            References(x => x.ReturnPort).Column("ret_port");

            HasOne(x => x.CommunicationServices).PropertyRef(r => r.Trip).Cascade.All();
            HasOne(x => x.TripMonitor).PropertyRef(r => r.Trip).Cascade.All();
            HasOne(x => x.Inspection).PropertyRef(r => r.Trip).Cascade.All();

            HasMany(x => x.Sightings).KeyColumn("obstrip_id");
            HasMany(x => x.Transfers).KeyColumn("obstrip_id");
            HasMany(x => x.PollutionEvents).KeyColumn("obstrip_id");
            HasMany(x => x.Electronics).KeyColumn("obstrip_id");
            HasMany(x => x.Interactions).KeyColumn("obstrip_id");
            
            DiscriminateSubClassesOnColumn<string>("gear_code");
        }
    }

    /// <summary>
    /// Mapping for purse seine specific data.
    /// </summary>
    public sealed class PurseSeineTripMap : SubclassMap<PurseSeineTrip>
    {
        public PurseSeineTripMap()
        {
            DiscriminatorValue("S");
            HasMany(x => x.SeaDays).KeyColumn("obstrip_id");
            HasMany(x => x.Crew).KeyColumn("obstrip_id");
            HasMany(x => x.WellContent).KeyColumn("obstrip_id");
            HasOne(x => x.Gear).PropertyRef(r => r.Trip).Cascade.All();
            HasOne(x => x.VesselAttributes).PropertyRef(r => r.Trip).Cascade.All();
        }
    }

    /// <summary>
    /// Mapping for long line specific data.
    /// </summary>
    public sealed class LongLineTripMap : SubclassMap<LongLineTrip>
    {
        public LongLineTripMap()
        {
            DiscriminatorValue("L");
        }
    }

    public sealed class PoleAndLineTripMap : SubclassMap<PoleAndLineTrip>
    {
        public PoleAndLineTripMap()
        {
            DiscriminatorValue("P");
        }
    }
}
