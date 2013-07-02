// -----------------------------------------------------------------------
// <copyright file="LongLineSetMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the LongLineSet entity.
    /// </summary>
    public sealed class LongLineSetMap : ClassMap<LongLineSet>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public LongLineSetMap()
        {
            Schema("obsv");
            Table("l_set");
            Id(x => x.Id, "l_set_id").GeneratedBy.Identity();
            Map(x => x.SetNumber, "set_number");
            Map(x => x.WasObserved, "observed_yn").CustomType<YesNoType>();
            Map(x => x.SetDateOnly, "set_date");
            Map(x => x.SetTimeOnly, "set_time").Length(4);
            Map(x => x.SetDate, "set_dtime");
            Map(x => x.UtcSetDateOnly, "utc_set_date");
            Map(x => x.UtcSetTimeOnly, "utc_set_time").Length(4);
            Map(x => x.LocalTime, "local_time").Length(4);
            Map(x => x.SetId, "set_id"); // Legacy data
            Map(x => x.UtcSetDate, "utc_set_dtime");
            Map(x => x.TargetSpeciesCode, "tar_sp_code");
            Map(x => x.IsTargetingTuna, "target_tun_yn");
            Map(x => x.IsTargetingSwordfish, "target_swo_yn");
            Map(x => x.IsTargetingSharks, "target_skh_yn"); // TODO Fix column name?
            Map(x => x.HooksPerBasket, "hk_bt_flt");
            Map(x => x.TotalBasketCount, "bask_set");
            Map(x => x.TotalHookCount, "hook_set");
            Map(x => x.EstimatedHookCount, "hook_est");
            Map(x => x.FloatlineLength, "float_length");
            Map(x => x.FloatlineHookCount, "floathook"); // ???
            Map(x => x.LineSettingSpeed, "lspeed").Precision(5).Scale(1);
            Map(x => x.LineSettingSpeedUnit, "lspeed_unit3_id").CustomType<UnitOfMeasure>();
            Map(x => x.LineSettingSpeedMetersPerSecond, "lspeed_mpersec").Precision(5).Scale(1);
            Map(x => x.VesselSpeed, "vessel_speed").Precision(5).Scale(1);
            Map(x => x.BranchlineSetInterval, "branch_intvl");
            Map(x => x.DistanceBetweenBranchlines, "branch_dist");
            Map(x => x.BranchlineLength, "branch_length");
            Map(x => x.SharkLineCount, "hook99_n");
            Map(x => x.SharkLineLength, "hook99_length");
            Map(x => x.TdrDeployed, "tdr_deployed_ans").CustomType<YesNoType>();
            Map(x => x.TotalHooksObserved, "hook_observed");
            Map(x => x.TotalBasketsObserved, "bask_observed");
            Map(x => x.LightStickCount, "lightsticks");
            Map(x => x.Gen3Events, "gen3events_ans").CustomType<YesNoType>();
            Map(x => x.AllPositionsDirectlyObserved, "observdirect_ans").CustomType<YesNoType>();
            Map(x => x.MeasuringInstrument, "measureinst");

            Map(x => x.BaitSpecies1Code, "bait1_sp_code").Length(3);
            Map(x => x.BaitSpecies1Weight, "bait1_w");
            Map(x => x.BaitSpecies1Hooks, "bait1_h").Length(25);
            Map(x => x.BaitSpecies1Dyed, "bait1_dyed_yn");

            Map(x => x.BaitSpecies2Code, "bait2_sp_code").Length(3);
            Map(x => x.BaitSpecies2Weight, "bait2_w");
            Map(x => x.BaitSpecies2Hooks, "bait2_h").Length(25);
            Map(x => x.BaitSpecies2Dyed, "bait2_dyed_yn");

            Map(x => x.BaitSpecies3Code, "bait3_sp_code").Length(3);
            Map(x => x.BaitSpecies3Weight, "bait3_w");
            Map(x => x.BaitSpecies3Hooks, "bait3_h").Length(25);
            Map(x => x.BaitSpecies3Dyed, "bait3_dyed_yn");

            Map(x => x.BaitSpecies4Code, "bait4_sp_code").Length(3);
            Map(x => x.BaitSpecies4Weight, "bait4_w");
            Map(x => x.BaitSpecies4Hooks, "bait4_h").Length(25);
            Map(x => x.BaitSpecies4Dyed, "bait4_dyed_yn");

            Map(x => x.BaitSpecies5Code, "bait5_sp_code").Length(3);
            Map(x => x.BaitSpecies5Weight, "bait5_w");
            Map(x => x.BaitSpecies5Hooks, "bait5_h").Length(25);
            Map(x => x.BaitSpecies5Dyed, "bait5_dyed_yn");

            Map(x => x.HasToriPoles, "tori_poles_yn");
            Map(x => x.HasBirdCurtain, "bird_curtain_yn");
            Map(x => x.HasWeightedLines, "weighted_lines_yn");
            Map(x => x.HasUnderwaterChute, "underwater_chute_yn");

            Map(x => x.Details, "setdetails");
            Map(x => x.Strategy, "strategy");
            
            Map(x => x.HookCalc, "hook_calc").Length(1);
            Map(x => x.HookDepthLow, "depth_min");
            Map(x => x.HookDepthHigh, "depth_max");
            Map(x => x.BranchlineCount_00to20m, "branch_0_20");
            Map(x => x.BranchlineCount_20to34m, "branch_20_34");
            Map(x => x.BranchlineCount_35to50m, "branch_35_50");
            Map(x => x.BranchlineCount_50to99m, "branch_50_99");
            Map(x => x.HasRecordedData, "no_obsv_yn");

            Map(x => x.DiaryPage, "diarypage").Length(50);
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            // Moving to Inverse for these entities will probably change
            // the requirements for the Longline import
            HasMany(x => x.EventList)
                .KeyColumn("l_set_id")
                .Inverse()
                .Cascade.None();
            HasMany(x => x.NotesList)
                .KeyColumn("l_set_id")
                .Inverse()
                .Cascade.None();

            HasMany(x => x.CatchList).KeyColumn("l_set_id").Cascade.None();           
            HasMany(x => x.ConversionFactors).KeyColumn("l_set_id").Cascade.None();
            

            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
