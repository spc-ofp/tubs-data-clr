// -----------------------------------------------------------------------
// <copyright file="PurseSeineSetMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// 
// This file is part of TUBS.
// 
//  TUBS is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// TUBS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PurseSeineSetMap : ClassMap<PurseSeineSet>
    {
        public PurseSeineSetMap()
        {
            Table("[obsv].[s_set]");
            Id(x => x.Id, "s_set_id").GeneratedBy.Identity();
            Map(x => x.SetNumber, "set_number");
            Map(x => x.StartOfSetFromLog, "vessellog_dtime");
            Map(x => x.SkiffOff, "skiffoff_dtime");
            Map(x => x.WinchOn, "winchon_dtime");
            Map(x => x.RingsUp, "ringup_dtime");
            Map(x => x.BeginBrailing, "sbrail_dtime");
            Map(x => x.EndBrailing, "ebrail_dtime");
            Map(x => x.EndOfSet, "stop_dtime");
            Map(x => x.WeightOnboardObserved, "ld_onboard");
            Map(x => x.WeightOnboardFromLog, "ld_ves_onboard");
            Map(x => x.RetainedTonnageObserved, "ld_tonnage");
            Map(x => x.RetainedTonnageFromLog, "ld_ves_tonnage");
            Map(x => x.VesselTonnageOnlyFromThisSet, "ld_fromthisset_ans");
            Map(x => x.NewOnboardTotalObserved, "ld_newonboard");
            Map(x => x.NewOnboardTotalFromLog, "ld_ves_newonboard");
            Map(x => x.TonsOfTunaObserved, "mttuna_obs");
            Map(x => x.SumOfBrail1, "ld_brails");
            Map(x => x.SumOfBrail2, "ld_brails2");
            Map(x => x.ContainsSkipjack, "totskj_ans");
            Map(x => x.SkipjackPercentage, "perc_skj");
            Map(x => x.TonsOfSkipjackObserved, "mtskj_obs");
            Map(x => x.ContainsYellowfin, "totyft_ans");
            Map(x => x.YellowfinPercentage, "perc_yft");
            Map(x => x.TonsOfYellowfinObserved, "mtyft_obs");
            Map(x => x.ContainsBigeye, "totbet_ans");
            Map(x => x.BigeyePercentage, "perc_bet");
            Map(x => x.TonsOfBigeyeObserved, "mtbet_obs");
            Map(x => x.ContainsLargeTuna, "totyftbet_ans"); // ???
            Map(x => x.LargeTunaPercentage, "perc_yftbet"); // ???
            Map(x => x.TonsOfYellowfinAndBigeyeObserved, "mtyftbet_obs"); // ???
            Map(x => x.TotalTunaAnswer, "tottun_ans");
            Map(x => x.PercentageOfTuna, "perc_tun");
            Map(x => x.TonsOfTunaObserved2, "mttun_obs");
            Map(x => x.LargeSpecies, "large_sp");
            Map(x => x.LargeSpeciesPercentage, "large_perc");
            Map(x => x.LargeSpeciesCount, "large_number");
            Map(x => x.TotalCatch, "total_catch");
            Map(x => x.RecoveredTagCount, "b_nbtags");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            HasOne(x => x.Activity).ForeignKey("s_daylog_id");
            HasMany(x => x.CatchList).KeyColumn("s_set_id").Cascade.All();
        }
    }
}
