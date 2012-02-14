// -----------------------------------------------------------------------
// <copyright file="MarineDeviceMap.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MarineDeviceMap : ClassMap<MarineDevice>
    {
        public MarineDeviceMap()
        {
            Table("obsv.ref_marine_devices");
            Id(x => x.Id, "device_id");
            Map(x => x.Description, "device_desc").Not.Nullable();
            Map(x => x.Category, "device_cat");
            Map(x => x.GearList, "gearlist").Length(3);
            Map(x => x.LongLineOrder, "order_l");
            Map(x => x.PurseSeineOrder, "order_s");
            Map(x => x.PoleAndLineOrder, "order_p");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
        }
    }
}
