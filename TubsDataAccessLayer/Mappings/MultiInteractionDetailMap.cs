// -----------------------------------------------------------------------
// <copyright file="MultiInteractionDetailMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the MultiInteractionDetail entity.
    /// </summary>
    public class MultiInteractionDetailMap : ClassMap<MultiInteractionDetail>
    {
        public MultiInteractionDetailMap()
        {
            Schema("obsv");
            Table("gen2multidetails");
            Id(x => x.Id, "spmultdetails_id").GeneratedBy.Identity();
            Map(x => x.SpeciesCode, "sp_code").Not.Nullable();
            Map(x => x.SexCode, "sex_code");
            Map(x => x.Length, "len").Precision(5).Scale(1);
            Map(x => x.LengthCode, "len_code");
            Map(x => x.LandedConditionCode, "landed_cond_code");
            Map(x => x.LandedConditionDescription, "landed_cond_desc");
            Map(x => x.DiscardedConditionCode, "discard_cond_code");
            Map(x => x.DiscardedConditionDescription, "discard_cond_desc");
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.Header).Column("spmulti_id");
        }
    }
}
