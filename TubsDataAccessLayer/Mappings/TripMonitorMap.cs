// -----------------------------------------------------------------------
// <copyright file="TripMonitorMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the TripMonitor entity.
    /// </summary>
    public sealed class TripMonitorMap : ClassMap<TripMonitor>
    {
        public TripMonitorMap()
        {
            Schema("obsv");
            Table("gen3tripmon");
            Id(x => x.Id, "gen3_id").GeneratedBy.Identity();
            Map(x => x.Question1, "q1_ans").CustomType<YesNoType>();
            Map(x => x.Question2, "q2_ans").CustomType<YesNoType>();
            Map(x => x.Question3, "q3_ans").CustomType<YesNoType>();
            Map(x => x.Question4, "q4_ans").CustomType<YesNoType>();
            Map(x => x.Question5, "q5_ans").CustomType<YesNoType>();
            Map(x => x.Question6, "q6_ans").CustomType<YesNoType>();
            Map(x => x.Question7, "q7_ans").CustomType<YesNoType>();
            Map(x => x.Question8, "q8_ans").CustomType<YesNoType>();
            Map(x => x.Question9, "q9_ans").CustomType<YesNoType>();
            Map(x => x.Question10, "q10_ans").CustomType<YesNoType>();
            Map(x => x.Question11, "q11_ans").CustomType<YesNoType>();
            Map(x => x.Question12, "q12_ans").CustomType<YesNoType>();
            Map(x => x.Question13, "q13_ans").CustomType<YesNoType>();
            Map(x => x.Question14, "q14_ans").CustomType<YesNoType>();
            Map(x => x.Question15, "q15_ans").CustomType<YesNoType>();
            Map(x => x.Question16, "q16_ans").CustomType<YesNoType>();
            Map(x => x.Question17, "q17_ans").CustomType<YesNoType>();
            Map(x => x.Question18, "q18_ans").CustomType<YesNoType>();
            Map(x => x.Question19, "q19_ans").CustomType<YesNoType>();
            Map(x => x.Question20, "q20_ans").CustomType<YesNoType>();
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.Trip).Column("obstrip_id");
            // From experimentation, it appears that if we want to automatically save child records on update,
            // we need to set inverse and use the AddXXX(...) methods on the parent.
            // If we _don't_ set .Inverse(), then child records aren't automatically updated and will need to
            // be manually updated via the appropriate Repository.
            HasMany(x => x.Details).KeyColumn("gen3_id").Inverse().Cascade.All();
        }
    }
}
