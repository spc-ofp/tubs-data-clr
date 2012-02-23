/// -----------------------------------------------------------------------
// <copyright file="GearMap.cs" company="Secretariat of the Pacific Community">
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
    /// Base mapping for all gear types.
    /// </summary>
    public abstract class BaseGearMap<T> : ClassMap<T> where T : Gear
    {
        protected BaseGearMap()
        {
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Trip).Column("obstrip_id");
        }
    }

    public sealed class PurseSeineGearMap : BaseGearMap<PurseSeineGear>
    {
        public PurseSeineGearMap()
        {
            Table("obsv.s_gear");
            Id(x => x.Id, "s_gear_id").GeneratedBy.Identity();
            Map(x => x.PowerblockMake, "pb_make");
            Map(x => x.PowerblockModel, "pb_model");
            Map(x => x.PowerblockPower, "pb_power");
            Map(x => x.PowerblockSpeed, "pb_speed");

            Map(x => x.PurseWinchMake, "pw_make");
            Map(x => x.PurseWinchModel, "pw_model");
            Map(x => x.PurseWinchPower, "pw_power");
            Map(x => x.PurseWinchSpeed, "pw_speed");

            Map(x => x.NetDepth, "net_depth");
            Map(x => x.NetDepthUnit, "net_depth_unit1_id").CustomType<UnitOfMeasure>();
            Map(x => x.NetDepthInMeters, "net_depth_m");

            Map(x => x.NetLength, "net_length");
            Map(x => x.NetLengthUnits, "net_length_unit1_id").CustomType<UnitOfMeasure>();
            Map(x => x.NetLengthInMeters, "net_length_m");

            Map(x => x.NetStrips, "net_strips");
            Map(x => x.NetHangRatio, "net_hang_ratio");
            Map(x => x.MeshSize, "mesh_main");
            Map(x => x.MeshSizeUnits, "mesh_main_unit2_id").CustomType<UnitOfMeasure>();
            Map(x => x.MeshSizeInCm, "mesh_main_cm");

            Map(x => x.Brail1Size, "brail_size1");
            Map(x => x.Brail2Size, "brail_size2");
            Map(x => x.BrailType, "brail_type");
        }
    }
}
