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
            Map(x => x.EventTime, "sighting_dtime");
            Map(x => x.Latitude, "lat");
            Map(x => x.Longitude, "lon");
            Map(x => x.VesselType, "vatyp_id").CustomType(typeof(VesselType));
            Map(x => x.Bearing, "bearing_dir");
            Map(x => x.Distance, "distance");
            Map(x => x.DistanceUnit, "dist_unit");
            Map(x => x.ActionType, "action_code");
            Map(x => x.PhotoNumber, "photo_number");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
