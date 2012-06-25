﻿// -----------------------------------------------------------------------
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
    public class LongLineSetMap : ClassMap<LongLineSet>
    {
        public LongLineSetMap()
        {
            Schema("obsv");
            Table("l_set");
            Id(x => x.Id, "s_set_id").GeneratedBy.Identity();
            Map(x => x.SetNumber, "set_number");
            Map(x => x.WasObserved, "observed_yn").CustomType<YesNoType>();
            Map(x => x.SetDateOnly, "set_date");
            Map(x => x.SetTimeOnly, "set_time");
            Map(x => x.SetDate, "set_dtime");
            Map(x => x.UtcSetDateOnly, "utc_set_date");
            Map(x => x.UtcSetTimeOnly, "utc_set_time");
            Map(x => x.UtcSetDate, "utc_set_dtime");
            Map(x => x.HooksPerBasket, "hk_bt_flt");
            Map(x => x.TotalBasketCount, "bask_set");
            Map(x => x.BasketsObserved, "bask_observed");
            Map(x => x.HookCount, "hook_set");
            Map(x => x.EstimatedHookCount, "hook_est");
            Map(x => x.ObservedHookCount, "hook_observed");
            Map(x => x.CalculatedHookCount, "hook_calc"); // This isn't correct
            Map(x => x.LengthOfFloatline, "float_length");
            Map(x => x.LineSettingSpeed, "lspeed").Precision(5).Scale(1);
            Map(x => x.LineSettingSpeedUnit, "lspeed_unit3_id").CustomType<UnitOfMeasure>(); // This needs fixing, should be int
            Map(x => x.LineSettingSpeedMetersPerSecond, "lspeed_mpersec").Precision(5).Scale(1);
            Map(x => x.BranchlineSetInterval, "branch_intvl");
            Map(x => x.MetersBetweenBranchlines, "branch_dist");



            /*Map(x => x.StartOfSetFromLog, "vessellog_dtime");
            Map(x => x.SkiffOff, "skiffoff_dtime");
            Map(x => x.SkiffOffTimeOnly, "skiffoff_time").Length(4);
            Map(x => x.WinchOn, "winchon_dtime");
            Map(x => x.WinchOnTimeOnly, "winchon_time").Length(4);
            Map(x => x.RingsUp, "ringup_dtime");
            Map(x => x.RingsUpTimeOnly, "ringup_time").Length(4);
            Map(x => x.BeginBrailing, "sbrail_dtime");
            Map(x => x.BeginBrailingTimeOnly, "sbrail_time").Length(4);
            Map(x => x.EndBrailing, "ebrail_dtime");
            Map(x => x.EndBrailingTimeOnly, "ebrail_time").Length(4);
            Map(x => x.EndOfSet, "stop_dtime");
            Map(x => x.EndOfSetTimeOnly, "stop_time").Length(4);
            // Group decimals together
            Map(x => x.WeightOnboardObserved, "ld_onboard").Precision(8).Scale(3);
            Map(x => x.WeightOnboardFromLog, "ld_ves_onboard").Precision(8).Scale(3);
            Map(x => x.RetainedTonnageObserved, "ld_tonnage").Precision(8).Scale(3);
            Map(x => x.RetainedTonnageFromLog, "ld_ves_tonnage").Precision(8).Scale(3);
            Map(x => x.NewOnboardTotalObserved, "ld_newonboard").Precision(8).Scale(3);
            Map(x => x.NewOnboardTotalFromLog, "ld_ves_newonboard").Precision(8).Scale(3);
            Map(x => x.TonsOfTunaObserved, "mttuna_obs").Precision(8).Scale(3);
            Map(x => x.SumOfBrail1, "ld_brails").Precision(8).Scale(3); // Updated in v2009 from p6 s1 to p8 s3
            Map(x => x.SumOfBrail2, "ld_brails2").Precision(8).Scale(3); // Updated in v2009 from p6 s1 to p8 s3
            Map(x => x.TonsOfSkipjackObserved, "mtskj_obs").Precision(8).Scale(3);
            Map(x => x.TonsOfYellowfinObserved, "mtyft_obs").Precision(8).Scale(3);
            Map(x => x.TonsOfBigeyeObserved, "mtbet_obs").Precision(8).Scale(3);
            Map(x => x.TonsOfYellowfinAndBigeyeObserved, "mtyftbet_obs").Precision(8).Scale(3); // ???
            Map(x => x.TonsOfTunaObserved2, "mttun_obs").Precision(8).Scale(3);
            Map(x => x.TotalCatch, "total_catch").Precision(8).Scale(3);

            // Group Booleans together
            Map(x => x.VesselTonnageOnlyFromThisSet, "ld_fromthisset_ans").CustomType<YesNoType>();
            Map(x => x.ContainsSkipjack, "totskj_ans").CustomType<YesNoType>();
            Map(x => x.ContainsYellowfin, "totyft_ans").CustomType<YesNoType>();
            Map(x => x.ContainsBigeye, "totbet_ans").CustomType<YesNoType>();
            Map(x => x.ContainsLargeTuna, "totyftbet_ans").CustomType<YesNoType>(); // ???
            Map(x => x.TotalTunaAnswer, "tottun_ans").CustomType<YesNoType>();
            // New v2009 fields
            Map(x => x.ContainsLargeYellowfin, "large_yft_ans").CustomType<YesNoType>();
            Map(x => x.ContainsLargeBigeye, "large_bet_ans").CustomType<YesNoType>();

            Map(x => x.SkipjackPercentage, "perc_skj");           
            Map(x => x.YellowfinPercentage, "perc_yft");           
            Map(x => x.BigeyePercentage, "perc_bet");            
            Map(x => x.LargeTunaPercentage, "perc_yftbet"); // ???           
            Map(x => x.PercentageOfTuna, "perc_tun");
            
            Map(x => x.LargeSpecies, "large_sp").Length(10);
            Map(x => x.LargeSpeciesPercentage, "large_perc");
            Map(x => x.LargeSpeciesCount, "large_number");
            
            Map(x => x.RecoveredTagCount, "b_nbtags");
            */

            Map(x => x.Details, "setdetails");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            //References(x => x.Activity).Column("s_daylog_id");
            //HasMany(x => x.CatchList).KeyColumn("s_set_id").Cascade.None();
            //HasMany(x => x.SamplingHeaders).KeyColumn("s_set_id").Cascade.None();
        }
    }
}
