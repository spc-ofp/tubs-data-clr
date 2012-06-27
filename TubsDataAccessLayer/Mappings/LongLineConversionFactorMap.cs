// -----------------------------------------------------------------------
// <copyright file="LongLineConversionFactorMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the LongLineConversionFactor entity.
    /// </summary>
    public class LongLineConversionFactorMap : ClassMap<LongLineConversionFactor>
    {
        public LongLineConversionFactorMap()
        {
            Schema("obsv");
            Table("l_cfactor");
            Id(x => x.Id, "l_cfact_id").GeneratedBy.Identity();
            Map(x => x.DateOnly, "catch_date");
            Map(x => x.TimeOnly, "catch_time").Length(4);
            Map(x => x.Date, "catch_dtime");
            Map(x => x.LabelNumber, "label_no");
            Map(x => x.SpeciesCode, "sp_code").Length(3);
            Map(x => x.TtLength, "len_tt");
            Map(x => x.UfLength, "len_uf");
            Map(x => x.UsLength, "len_us");
            Map(x => x.LfLength, "len_lf");
            Map(x => x.PfLength, "len_pf");
            Map(x => x.PsLength, "len_ps");
            Map(x => x.SlLength, "len_sl");
            Map(x => x.EoLength, "len_eo");
            Map(x => x.CkLength, "len_ck");
            Map(x => x.TlLength, "len_tl");
            Map(x => x.CuLength, "len_cu");
            Map(x => x.WwWeight, "wt_ww").Precision(5).Scale(1);
            Map(x => x.HeadWeight, "wt_head").Precision(5).Scale(1);
            Map(x => x.TailWeight, "wt_tail").Precision(5).Scale(1);
            Map(x => x.GutsWeight, "wt_guts").Precision(5).Scale(1);
            Map(x => x.WetfinWeight, "wt_wetfin").Precision(5).Scale(1);
            Map(x => x.ProcessedWeight, "proc_wt").Precision(5).Scale(1);
            Map(x => x.ProcessedWeightCode, "proc_wt_code");
            Map(x => x.LandedWeight, "land_wt").Precision(5).Scale(1);
            Map(x => x.LandedWeightCode, "land_wt_code");

            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.FishingSet).Column("l_set_id");
        }
    }
}
