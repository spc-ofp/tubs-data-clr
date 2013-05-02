// -----------------------------------------------------------------------
// <copyright file="LongLineSetHaulEventMap.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Entities;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public sealed class LongLineSetHaulEventMap : ClassMap<LongLineSetHaulEvent>
    {
        public LongLineSetHaulEventMap()
        {
            Schema("obsv");
            Table("l_sethaullog");
            Id(x => x.Id, "l_setlog_id").GeneratedBy.Identity();
            Map(x => x.LogDateOnly, "log_date");
            Map(x => x.LogTimeOnly, "log_time").Length(4);
            Map(x => x.LogDate, "log_dtime");
            Map(x => x.Sethaul, "sethaul").Length(4);
            Map(x => x.ActivityType, "stend_id").CustomType<HaulActivityType>();
            Map(x => x.Latitude, "lat").Length(9);
            Map(x => x.Longitude, "lon").Length(10);
            Map(x => x.EezCode, "eez_code").Length(2);
            Map(x => x.WindDirection, "wind_dir");
            Map(x => x.WindSpeed, "wind_kts");
            Map(x => x.SeaCode, "sea_code");
            Map(x => x.CloudCover, "cloud");

            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");           

            References(x => x.FishingSet).Column("l_set_id");
        }
    }
}
