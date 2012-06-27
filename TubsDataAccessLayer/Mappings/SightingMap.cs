// -----------------------------------------------------------------------
// <copyright file="SightingMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
{
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Fluent NHibernate mapping for the Sighting entity.
    /// </summary>
    public sealed class SightingMap : ClassMap<Sighting>
    {
        public SightingMap()
        {
            Schema("obsv");
            Table("gen1sightings");
            Id(x => x.Id, "sighting_id").GeneratedBy.Identity();
            Map(x => x.FormId, "form_id");
            Map(x => x.EventDateOnly, "sighting_date");
            Map(x => x.EventTimeOnly, "sighting_time").Length(4);
            Map(x => x.EventDate, "sighting_dtime");
            Map(x => x.Latitude, "lat").Length(9);
            Map(x => x.Longitude, "lon").Length(10);
            Map(x => x.EezCode, "eez_code").Length(2);
            Map(x => x.VesselType, "vatyp_id").CustomType(typeof(SightedVesselType));
            Map(x => x.VesselName, "vessel_name").Length(50);
            Map(x => x.VesselFlag, "reg_country_code").Length(2);
            Map(x => x.Ircs, "ircs").Length(16);
            Map(x => x.Bearing, "bearing_dir");
            Map(x => x.Distance, "distance");
            Map(x => x.DistanceUnit, "dist_unit");
            Map(x => x.ActionType, "action_code");
            Map(x => x.PhotoNumber, "photo_number");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.Vessel).Column("vessel_id");
            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
