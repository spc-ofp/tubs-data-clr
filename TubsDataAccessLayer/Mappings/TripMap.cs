// -----------------------------------------------------------------------
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
            Schema("obsv");
            Table("trip");
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
            // Updated properties
            Map(x => x.RegistrationId, "regist_id");
            Map(x => x.ClosedDate, "closed_date");
            Map(x => x.VerifiedBy, "verified_by");
            Map(x => x.VerifiedDate, "verified_dtime");
            Map(x => x.IsFullTrip, "fulltrip");
            Map(x => x.IsSharkTarget, "sharktarget");            
            Map(x => x.CkTripNumber, "tripno_ck");
            Map(x => x.FmTripNumber, "tripno_fm");
            Map(x => x.FfaTripNumber, "tripno_ffa");
            Map(x => x.SbTripNumber, "tripno_sb");
            Map(x => x.HwTripNumber, "tripno_hw");
            Map(x => x.Comments, "comments");
            Map(x => x.ProjectCode, "project_code");
            Map(x => x.IsCadetTrip, "cadet");
            Map(x => x.WellCapacity, "well_capacity").Precision(8).Scale(3);

            // FIXME Spill Observer is b0rked in backing database
            Map(x => x.IsSpillSampled, "spill");
            Map(x => x.SpillTripNumber, "spill_tripno");

            // Fill in VesselNotes as subordinate object
            Component(x => x.VesselNotes, m =>
            {
                m.Map(x => x.Owner, "vesowner");
                m.Map(x => x.Captain, "vescaptain");                
                m.Map(x => x.CaptainCountryCode, "vescaptain_country_code");
                m.Map(x => x.FishingMaster, "vesmaster");
                m.Map(x => x.MasterCountryCode, "vesmaster_country_code");
                m.Map(x => x.Licenses, "licences");
                m.Map(x => x.Comments, "form1_comments");
            });


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
            HasMany(x => x.WellReconciliations).KeyColumn("obstrip_id");

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
