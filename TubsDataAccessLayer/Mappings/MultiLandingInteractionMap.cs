// -----------------------------------------------------------------------
// <copyright file="MultiLandingInteractionMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the MultiLandingInteraction entity.
    /// </summary>
    public class MultiLandingInteractionMap : ClassMap<MultiLandingInteraction>
    {
        public MultiLandingInteractionMap()
        {
            Schema("obsv");
            Table("gen2multi");
            Id(x => x.Id, "spmulti_id");
            Map(x => x.LandedDateOnly, "landed_date");
            Map(x => x.LandedTimeOnly, "landed_time");
            Map(x => x.LandedDate, "landed_dtime");
            Map(x => x.MeasuringInstrument, "measure").Length(50);
            Map(x => x.ContinuedOnPs4, "ps4_form_yn");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            HasMany(x => x.Details).KeyColumn("spmulti_id");
            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
