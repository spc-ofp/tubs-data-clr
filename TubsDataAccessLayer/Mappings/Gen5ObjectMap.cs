// -----------------------------------------------------------------------
// <copyright file="Gen5ObjectMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the Gen5Object entity.
    /// </summary>
    public sealed class Gen5ObjectMap : ClassMap<Gen5Object>
    {
        public Gen5ObjectMap()
        {
            Schema("obsv");
            Table("gen5fad");
            Id(x => x.Id, "fad_id").GeneratedBy.Identity();
            Map(x => x.ObjectNumber, "object_number");
            Map(x => x.Origin, "origin_code").CustomType<FadOrigin>();
            Map(x => x.DeploymentDate, "deployment_date");
            Map(x => x.Latitude, "lat").Length(9);
            Map(x => x.Longitude, "lon").Length(10);
            Map(x => x.IsSsiTrapped, "ssi_trapped").CustomType<YesNoType>();
            Map(x => x.AsFound, "as_found_code").CustomType<FadType>();
            Map(x => x.AsLeft, "as_left_code").CustomType<FadType>();
            Map(x => x.Depth, "max_depth_m");
            Map(x => x.Length, "length_m");
            Map(x => x.Width, "width_m");
            Map(x => x.BuoyNumber, "buoy_number").Length(20);
            Map(x => x.Markings, "markings").Length(50);
            Map(x => x.Comments, "comments");

            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            HasMany(x => x.Materials)
                .KeyColumn("fad_id")
                .Inverse() // Tried this the other way and no dice...
                .Cascade
                .None();
            References(x => x.Activity).Column("s_daylog_id");
        }
    }
}
