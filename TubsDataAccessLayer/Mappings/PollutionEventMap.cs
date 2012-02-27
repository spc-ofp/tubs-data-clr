// -----------------------------------------------------------------------
// <copyright file="PollutionEventMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the PollutionEvent entity.
    /// </summary>
    public sealed class PollutionEventMap : ClassMap<PollutionEvent>
    {
        public PollutionEventMap()
        {
            Schema("obsv");
            Table("gen6poll");
            Id(x => x.Id, "pollution_id").GeneratedBy.Identity();
            Map(x => x.FormId, "form_id");
            Map(x => x.IncidentDate, "inc_dtime");
            Map(x => x.Latitude, "lat");
            Map(x => x.Longitude, "lon");
            Map(x => x.EezId, "eez_code");
            Map(x => x.WindDirection, "wind_dir");
            Map(x => x.WindSpeed, "wind_kts");
            Map(x => x.SeaCode, "sea_code");
            Map(x => x.CurrentSpeed, "current_speed");
            Map(x => x.CurrentDirection, "current_dir");
            Map(x => x.ActivityType, "activ_id").CustomType(typeof(ActivityType));
            Map(x => x.VesselName, "vessel_name").Length(50);
            Map(x => x.Ircs, "ircs").Length(16);
            Map(x => x.Bearing, "bearing_dir");
            Map(x => x.Distance, "distance");
            Map(x => x.Comments, "comments");
            Map(x => x.MarpolStickers, "stickers_ans").CustomType(typeof(YesNoType));
            Map(x => x.CaptainAware, "aware_ans").CustomType(typeof(YesNoType));
            Map(x => x.CaptainAdvised, "advised_ans").CustomType(typeof(YesNoType));
            Map(x => x.PhotosTaken, "photos_ans").CustomType(typeof(YesNoType));
            Map(x => x.PhotoFrames, "photo_numbers");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Trip).Column("obstrip_id");
            HasMany(x => x.Details).KeyColumn("pollution_id").Cascade.All();
        }
    }
}
