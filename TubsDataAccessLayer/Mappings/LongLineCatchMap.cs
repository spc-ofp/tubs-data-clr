// -----------------------------------------------------------------------
// <copyright file="LongLineCatchMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the LongLineCatch entity.
    /// </summary>
    public sealed class LongLineCatchMap : ClassMap<LongLineCatch>
    {
        public LongLineCatchMap()
        {
            Schema("obsv");
            Table("l_setcatch");
            Id(x => x.Id, "l_setcatch_id").GeneratedBy.Identity();
            Map(x => x.DateOnly, "catch_date");
            Map(x => x.TimeOnly, "catch_time").Length(4);
            Map(x => x.Date, "catch_dtime");
            Map(x => x.SampleNumber, "sample_no");
            Map(x => x.HookNumber, "hook_no");
            Map(x => x.SpeciesCode, "sp_code").Length(3);
            Map(x => x.LandedConditionCode, "cond_code"); //.CustomType<ConditionCode>();
            Map(x => x.DiscardedConditionCode, "cond_code2");
            Map(x => x.FateCode, "fate_code");
            Map(x => x.Length, "len");
            Map(x => x.LengthCode, "len_code");
            Map(x => x.Weight, "wt").Precision(5).Scale(1);
            Map(x => x.EstimatedWeight, "wt_est").Precision(5).Scale(1);
            Map(x => x.EstimatedWeightReliability, "wt_est_rel");
            Map(x => x.SexCode, "sex_code");
            Map(x => x.Spare1, "spare1").Length(50);
            Map(x => x.GonadStage, "gstage_id").CustomType<GonadStage>();
            Map(x => x.Comments, "comments").Length(40);
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
