// -----------------------------------------------------------------------
// <copyright file="BrailMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the BrailMap entity.
    /// </summary>
    public sealed class BrailMap : ClassMap<Brail>
    {
        public BrailMap()
        {
            Table("obsv.s_lfbrails");
            Id(x => x.Id, "s_lfbrail_id").GeneratedBy.Identity();
            Map(x => x.BrailNumber, "whichbrail");
            Map(x => x.PageNumber, "pagenumber");
            Map(x => x.PageCount, "pagemax");
            Map(x => x.FishPerBrail, "fish_per_brail");
            Map(x => x.MeasuringInstrument, "measure").Length(20);
            Map(x => x.LengthCode, "len_code").Length(2);
            Map(x => x.FullBrailCount, "brail_full_n");
            Map(x => x.SevenEighthsBrailCount, "brail_78_n");
            Map(x => x.ThreeQuartersBrailCount, "brail_34_n");
            Map(x => x.TwoThirdsBrailCount, "brail_23_n");
            Map(x => x.OneHalfBrailCount, "brail_12_n");
            Map(x => x.OneThirdBrailCount, "brail_13_n");
            Map(x => x.OneQuarterBrailCount, "brail_14_n");
            Map(x => x.OneEighthBrailCount, "brail_18_n");
            Map(x => x.TotalBrailCount, "brail_n");
            Map(x => x.SumOfAllBrails, "sum_brails");
            Map(x => x.Brail1FullnessCode, "brail1_fullness");
            Map(x => x.SamplesFromBrail1, "brail1_samples");
            Map(x => x.Brail2FullnessCode, "brail2_fullness");
            Map(x => x.SamplesFromBrail2, "brail2_samples");
            Map(x => x.Brail3FullnessCode, "brail3_fullness");
            Map(x => x.SamplesFromBrail3, "brail3_samples");
            Map(x => x.Brail4FullnessCode, "brail4_fullness");
            Map(x => x.SamplesFromBrail4, "brail4_samples");
            Map(x => x.Brail5FullnessCode, "brail5_fullness");
            Map(x => x.SamplesFromBrail5, "brail5_samples");
            Map(x => x.Brail6FullnessCode, "brail6_fullness");
            Map(x => x.SamplesFromBrail6, "brail6_samples");
            Map(x => x.Brail7FullnessCode, "brail7_fullness");
            Map(x => x.SamplesFromBrail7, "brail7_samples");
            Map(x => x.Brail8FullnessCode, "brail8_fullness");
            Map(x => x.SamplesFromBrail8, "brail8_samples");
            Map(x => x.Brail9FullnessCode, "brail9_fullness");
            Map(x => x.SamplesFromBrail9, "brail9_samples");
            Map(x => x.Brail10FullnessCode, "brail10_fullness");
            Map(x => x.SamplesFromBrail10, "brail10_samples");
            Map(x => x.Brail11FullnessCode, "brail11_fullness");
            Map(x => x.SamplesFromBrail11, "brail11_samples");
            Map(x => x.Brail12FullnessCode, "brail12_fullness");
            Map(x => x.SamplesFromBrail12, "brail12_samples");
            Map(x => x.Brail13FullnessCode, "brail13_fullness");
            Map(x => x.SamplesFromBrail13, "brail13_samples");
            Map(x => x.Brail14FullnessCode, "brail14_fullness");
            Map(x => x.SamplesFromBrail14, "brail14_samples");
            Map(x => x.Brail15FullnessCode, "brail15_fullness");
            Map(x => x.SamplesFromBrail15, "brail15_samples");
            Map(x => x.Brail16FullnessCode, "brail16_fullness");
            Map(x => x.SamplesFromBrail16, "brail16_samples");
            Map(x => x.Brail17FullnessCode, "brail17_fullness");
            Map(x => x.SamplesFromBrail17, "brail17_samples");
            Map(x => x.Brail18FullnessCode, "brail18_fullness");
            Map(x => x.SamplesFromBrail18, "brail18_samples");
            Map(x => x.Brail19FullnessCode, "brail19_fullness");
            Map(x => x.SamplesFromBrail19, "brail19_samples");
            Map(x => x.Brail20FullnessCode, "brail20_fullness");
            Map(x => x.SamplesFromBrail20, "brail20_samples");
            Map(x => x.Brail21FullnessCode, "brail21_fullness");
            Map(x => x.SamplesFromBrail21, "brail21_samples");
            Map(x => x.Brail22FullnessCode, "brail22_fullness");
            Map(x => x.SamplesFromBrail22, "brail22_samples");
            Map(x => x.Brail23FullnessCode, "brail23_fullness");
            Map(x => x.SamplesFromBrail23, "brail23_samples");
            Map(x => x.Brail24FullnessCode, "brail24_fullness");
            Map(x => x.SamplesFromBrail24, "brail24_samples");
            Map(x => x.Brail25FullnessCode, "brail25_fullness");
            Map(x => x.SamplesFromBrail25, "brail25_samples");
            Map(x => x.Brail26FullnessCode, "brail26_fullness");
            Map(x => x.SamplesFromBrail26, "brail26_samples");
            Map(x => x.Brail27FullnessCode, "brail27_fullness");
            Map(x => x.SamplesFromBrail27, "brail27_samples");
            Map(x => x.Brail28FullnessCode, "brail28_fullness");
            Map(x => x.SamplesFromBrail28, "brail28_samples");
            Map(x => x.Brail29FullnessCode, "brail29_fullness");
            Map(x => x.SamplesFromBrail29, "brail29_samples");
            Map(x => x.Brail30FullnessCode, "brail30_fullness");
            Map(x => x.SamplesFromBrail30, "brail30_samples");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Header).Column("s_lf_id");
        }
    }
}
