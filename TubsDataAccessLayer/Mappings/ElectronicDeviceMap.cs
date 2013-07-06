// -----------------------------------------------------------------------
// <copyright file="ElectronicDeviceMap.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Entities;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Fluent NHibernate mapping for the ElectronicDevice entity.
    /// </summary>
    public sealed class ElectronicDeviceMap : ClassMap<ElectronicDevice>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ElectronicDeviceMap()
        {
            Schema("obsv");
            Table("vess_electronics_detail");
            Id(x => x.Id, "elect_detail_id");
            Map(x => x.DeviceType, "device_id").CustomType<ElectronicDeviceType>();
            Map(x => x.Description, "device_desc").Length(255);
            Map(x => x.SystemDescription, "system_desc").Length(255);
            Map(x => x.IsInstalled, "isinstalled").CustomType(typeof(YesNoType));
            Map(x => x.Usage, "usage_code");
            Map(x => x.Make, "make_desc").Length(30);
            Map(x => x.Model, "model_desc").Length(30);
            Map(x => x.HowMany, "how_many");
            Map(x => x.SealsIntact, "seals_intact");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
