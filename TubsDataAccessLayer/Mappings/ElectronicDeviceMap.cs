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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ElectronicDeviceMap : ClassMap<ElectronicDevice>
    {
        public ElectronicDeviceMap()
        {
            Table("obsv.vess_electronics_detail");
            Id(x => x.Id, "elect_detail_id");
            Map(x => x.IsInstalled, "isinstalled").CustomType(typeof(YesNoType));
            Map(x => x.Usage, "usage_code");
            Map(x => x.Make, "make_desc").Length(30);
            Map(x => x.Model, "model_desc").Length(30);
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.DeviceType).Column("device_id");
            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
