// -----------------------------------------------------------------------
// <copyright file="LengthSamplingHeaderMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the LengthSamplingHeader entity.
    /// </summary>
    public sealed class LengthSamplingHeaderMap : ClassMap<LengthSamplingHeader>
    {
        public LengthSamplingHeaderMap()
        {
            Schema("obsv");
            Table("s_lf");
            Id(x => x.Id, "s_lf_id").GeneratedBy.Identity();
            Map(x => x.FormId, "form_id");
            Map(x => x.SamplingProtocol, "sampletype_id").CustomType(typeof(SamplingProtocol));
            Map(x => x.SamplingProtocolComments, "other_desc");
            Map(x => x.BrailStartTime, "sbrail_time").Length(4);
            Map(x => x.BrailEndTime, "ebrail_time").Length(4);

            // The following properties were migrated from s_lfbrails
            Map(x => x.BrailNumber, "whichbrail");
            Map(x => x.PageNumber, "pagenumber");
            Map(x => x.PageCount, "pagemax");
            Map(x => x.FishPerBrail, "fish_per_brail");
            Map(x => x.MeasuringInstrument, "measure").Length(20);
            Map(x => x.FullBrailCount, "brail_full_n");
            Map(x => x.SevenEighthsBrailCount, "brail_78_n");
            Map(x => x.ThreeQuartersBrailCount, "brail_34_n");
            Map(x => x.TwoThirdsBrailCount, "brail_23_n");
            Map(x => x.OneHalfBrailCount, "brail_12_n");
            Map(x => x.OneThirdBrailCount, "brail_13_n");
            Map(x => x.OneQuarterBrailCount, "brail_14_n");
            Map(x => x.OneEighthBrailCount, "brail_18_n");
            Map(x => x.TotalBrailCount, "brail_n");
            Map(x => x.SumOfAllBrails, "sum_brails").Precision(7).Scale(2);

            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            // Version 2009 workbook fields
            Map(x => x.SampledBrailNumber, "sampled_brail_num");
            Map(x => x.NumberOfFishMeasured, "measured_n");
            Map(x => x.CalibratedThisSet, "calibrated_this_set").CustomType<YesNoType>();

            References(x => x.Set).Column("s_set_id");
            HasMany(x => x.Samples).KeyColumn("s_lf_id").Cascade.All();
            HasMany(x => x.Brails).KeyColumn("s_lf_id").Cascade.All();
        }
    }
}
