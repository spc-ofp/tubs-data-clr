// -----------------------------------------------------------------------
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
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.Trip).Column("obstrip_id");
        }
    }

    public sealed class LongLineGearMap : BaseGearMap<LongLineGear>
    {
        public LongLineGearMap()
        {
            Schema("obsv");
            Table("l_gear");
            Id(x => x.Id, "l_gear_id").GeneratedBy.Identity();
            Map(x => x.HasMainlineHauler, "mlinehaul_ans").CustomType<YesNoType>();
            Map(x => x.MainlineHaulerUsage, "mlinehaul_usage_code");
            Map(x => x.MainlineHaulerComments, "mlinehaul_comments").Length(50);

            Map(x => x.HasBranchlineHauler, "blinehaul_ans").CustomType<YesNoType>();
            Map(x => x.BranchlineHaulerUsage, "blinehaul_usage_code");
            Map(x => x.BranchlineHaulerComments, "blinehaul_comments").Length(50);

            Map(x => x.HasLineShooter, "lshoot_ans").CustomType<YesNoType>();
            Map(x => x.LineShooterUsage, "lshoot_usage_code");
            Map(x => x.LineShooterComments, "lshoot_comments").Length(50);

            Map(x => x.HasBaitThrower, "baitthr_ans").CustomType<YesNoType>();
            Map(x => x.BaitThrowerUsage, "baitthr_usage_code");
            Map(x => x.BaitThrowerComments, "baitthr_comments").Length(50);

            Map(x => x.HasBranchlineAttacher, "branchatt_ans").CustomType<YesNoType>();
            Map(x => x.BranchlineAttacherUsage, "branchatt_usage_code");
            Map(x => x.BranchlineAttacherComments, "branchatt_comments").Length(50);

            Map(x => x.HasWeightScales, "weightsca_ans").CustomType<YesNoType>();
            Map(x => x.WeightScalesUsage, "weightsca_usage_code");
            Map(x => x.WeightScalesComments, "weightsca_comments").Length(50);

            Map(x => x.MainlineComposition, "mline_comp");
            Map(x => x.BranchlineComposition, "bline_comp");
            Map(x => x.MainlineMaterial, "mline_mat");
            Map(x => x.MainlineLength, "mline_len").Precision(5).Scale(1);
            Map(x => x.MainlineDiameter, "mline_diam").Precision(4).Scale(1);

            Map(x => x.BranchlineMaterial1, "bline_mat1").Length(40);
            Map(x => x.BranchlineMaterial1Description, "bline_mat1_desc").Length(50);

            Map(x => x.BranchlineMaterial2, "bline_mat2").Length(40);
            Map(x => x.BranchlineMaterial2Description, "bline_mat2_desc").Length(50);

            Map(x => x.BranchlineMaterial3, "bline_mat3").Length(40);
            Map(x => x.BranchlineMaterial3Description, "bline_mat3_desc").Length(50);

            Map(x => x.HasWireTrace, "wiretrace_ans").CustomType<YesNoType>();
            Map(x => x.HasRefrigeratedSeawater, "seawater_ans").CustomType<YesNoType>();
            Map(x => x.HasBlastFreezer, "blastfreezer_ans").CustomType<YesNoType>();
            Map(x => x.HasIce, "ice_ans").CustomType<YesNoType>();
            Map(x => x.HasChilledSeawater, "chilledseawater_ans").CustomType<YesNoType>();
            Map(x => x.HasOtherStorage, "otherstorage_ans").CustomType<YesNoType>();
            Map(x => x.OtherStorageDescription, "otherstorage_desc").Length(50);

            Map(x => x.JapanHookSize, "hksjapan_size").Length(50);
            Map(x => x.JapanHookPercentage, "hksjapan_perc");

            Map(x => x.CircleHookSize, "hkscircle_size").Length(50);
            Map(x => x.CircleHookPercentage, "hkscircle_perc");

            Map(x => x.JHookSize, "hksj_size").Length(50);
            Map(x => x.JHookPercentage, "hksj_perc");

            Map(x => x.OtherHookSize, "hksoth_size").Length(50);
            Map(x => x.OtherHookPercentage, "hksoth_perc");
            Map(x => x.OtherHookType, "hksoth_type").Length(50);
        }
    }

    public sealed class PurseSeineGearMap : BaseGearMap<PurseSeineGear>
    {
        public PurseSeineGearMap()
        {
            Schema("obsv");
            Table("s_gear");
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
