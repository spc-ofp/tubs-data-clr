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
            Schema("obsv");
            Table("s_lfbrails");
            Id(x => x.Id, "s_lfbrail_id").GeneratedBy.Identity();
            Component(x => x.Record1, m =>
            {
                // Fluent NHibernate doesn't have a constant mapping
                // so this serves as an adequate work-around
                m.Map(x => x.Sequence).Formula("1");
                m.Map(x => x.Samples, "brail1_samples");
                m.Map(x => x.Fullness, "brail1_fullness");
            });

            Component(x => x.Record2, m =>
            {
                m.Map(x => x.Sequence).Formula("2");
                m.Map(x => x.Samples, "brail2_samples");
                m.Map(x => x.Fullness, "brail2_fullness");
            });

            Component(x => x.Record3, m =>
            {
                m.Map(x => x.Sequence).Formula("3");
                m.Map(x => x.Samples, "brail3_samples");
                m.Map(x => x.Fullness, "brail3_fullness");
            });


            Component(x => x.Record4, m =>
            {
                m.Map(x => x.Sequence).Formula("4");
                m.Map(x => x.Samples, "brail4_samples");
                m.Map(x => x.Fullness, "brail4_fullness");
            });


            Component(x => x.Record5, m =>
            {
                m.Map(x => x.Sequence).Formula("5");
                m.Map(x => x.Samples, "brail5_samples");
                m.Map(x => x.Fullness, "brail5_fullness");
            });


            Component(x => x.Record6, m =>
            {
                m.Map(x => x.Sequence).Formula("6");
                m.Map(x => x.Samples, "brail6_samples");
                m.Map(x => x.Fullness, "brail6_fullness");
            });


            Component(x => x.Record7, m =>
            {
                m.Map(x => x.Sequence).Formula("7");
                m.Map(x => x.Samples, "brail7_samples");
                m.Map(x => x.Fullness, "brail7_fullness");
            });


            Component(x => x.Record8, m =>
            {
                m.Map(x => x.Sequence).Formula("8");
                m.Map(x => x.Samples, "brail8_samples");
                m.Map(x => x.Fullness, "brail8_fullness");
            });


            Component(x => x.Record9, m =>
            {
                m.Map(x => x.Sequence).Formula("9");
                m.Map(x => x.Samples, "brail9_samples");
                m.Map(x => x.Fullness, "brail9_fullness");
            });


            Component(x => x.Record10, m =>
            {
                m.Map(x => x.Sequence).Formula("10");
                m.Map(x => x.Samples, "brail10_samples");
                m.Map(x => x.Fullness, "brail10_fullness");
            });


            Component(x => x.Record11, m =>
            {
                m.Map(x => x.Sequence).Formula("11");
                m.Map(x => x.Samples, "brail11_samples");
                m.Map(x => x.Fullness, "brail11_fullness");
            });


            Component(x => x.Record12, m =>
            {
                m.Map(x => x.Sequence).Formula("12");
                m.Map(x => x.Samples, "brail12_samples");
                m.Map(x => x.Fullness, "brail12_fullness");
            });


            Component(x => x.Record13, m =>
            {
                m.Map(x => x.Sequence).Formula("13");
                m.Map(x => x.Samples, "brail13_samples");
                m.Map(x => x.Fullness, "brail13_fullness");
            });


            Component(x => x.Record14, m =>
            {
                m.Map(x => x.Sequence).Formula("14");
                m.Map(x => x.Samples, "brail14_samples");
                m.Map(x => x.Fullness, "brail14_fullness");
            });


            Component(x => x.Record15, m =>
            {
                m.Map(x => x.Sequence).Formula("15");
                m.Map(x => x.Samples, "brail15_samples");
                m.Map(x => x.Fullness, "brail15_fullness");
            });


            Component(x => x.Record16, m =>
            {
                m.Map(x => x.Sequence).Formula("16");
                m.Map(x => x.Samples, "brail16_samples");
                m.Map(x => x.Fullness, "brail16_fullness");
            });


            Component(x => x.Record17, m =>
            {
                m.Map(x => x.Sequence).Formula("17");
                m.Map(x => x.Samples, "brail17_samples");
                m.Map(x => x.Fullness, "brail17_fullness");
            });


            Component(x => x.Record18, m =>
            {
                m.Map(x => x.Sequence).Formula("18");
                m.Map(x => x.Samples, "brail18_samples");
                m.Map(x => x.Fullness, "brail18_fullness");
            });


            Component(x => x.Record19, m =>
            {
                m.Map(x => x.Sequence).Formula("19");
                m.Map(x => x.Samples, "brail19_samples");
                m.Map(x => x.Fullness, "brail19_fullness");
            });


            Component(x => x.Record20, m =>
            {
                m.Map(x => x.Sequence).Formula("20");
                m.Map(x => x.Samples, "brail20_samples");
                m.Map(x => x.Fullness, "brail20_fullness");
            });


            Component(x => x.Record21, m =>
            {
                m.Map(x => x.Sequence).Formula("21");
                m.Map(x => x.Samples, "brail21_samples");
                m.Map(x => x.Fullness, "brail21_fullness");
            });


            Component(x => x.Record22, m =>
            {
                m.Map(x => x.Sequence).Formula("22");
                m.Map(x => x.Samples, "brail22_samples");
                m.Map(x => x.Fullness, "brail22_fullness");
            });


            Component(x => x.Record23, m =>
            {
                m.Map(x => x.Sequence).Formula("23");
                m.Map(x => x.Samples, "brail23_samples");
                m.Map(x => x.Fullness, "brail23_fullness");
            });


            Component(x => x.Record24, m =>
            {
                m.Map(x => x.Sequence).Formula("24");
                m.Map(x => x.Samples, "brail24_samples");
                m.Map(x => x.Fullness, "brail24_fullness");
            });


            Component(x => x.Record25, m =>
            {
                m.Map(x => x.Sequence).Formula("25");
                m.Map(x => x.Samples, "brail25_samples");
                m.Map(x => x.Fullness, "brail25_fullness");
            });


            Component(x => x.Record26, m =>
            {
                m.Map(x => x.Sequence).Formula("26");
                m.Map(x => x.Samples, "brail26_samples");
                m.Map(x => x.Fullness, "brail26_fullness");
            });


            Component(x => x.Record27, m =>
            {
                m.Map(x => x.Sequence).Formula("27");
                m.Map(x => x.Samples, "brail27_samples");
                m.Map(x => x.Fullness, "brail27_fullness");
            });


            Component(x => x.Record28, m =>
            {
                m.Map(x => x.Sequence).Formula("28");
                m.Map(x => x.Samples, "brail28_samples");
                m.Map(x => x.Fullness, "brail28_fullness");
            });


            Component(x => x.Record29, m =>
            {
                m.Map(x => x.Sequence).Formula("29");
                m.Map(x => x.Samples, "brail29_samples");
                m.Map(x => x.Fullness, "brail29_fullness");
            });


            Component(x => x.Record30, m =>
            {
                m.Map(x => x.Sequence).Formula("30");
                m.Map(x => x.Samples, "brail30_samples");
                m.Map(x => x.Fullness, "brail30_fullness");
            });


            /*
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
             * 
            */
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");
            References(x => x.Header).Column("s_lf_id");
        }
    }
}
