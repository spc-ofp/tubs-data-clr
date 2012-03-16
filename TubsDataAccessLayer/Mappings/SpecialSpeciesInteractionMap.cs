// -----------------------------------------------------------------------
// <copyright file="SpecialSpeciesInteractionMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the SpecialSpeciesInteraction entity.
    /// </summary>
    public sealed class SpecialSpeciesInteractionMap : ClassMap<SpecialSpeciesInteraction>
    {
        public SpecialSpeciesInteractionMap()
        {
            Schema("obsv");
            Table("gen2special");
            Id(x => x.Id, "ssp_id");
            Map(x => x.SgType, "sgtype").Length(1);
            Map(x => x.SgTime, "sgtime").Length(1);
            Map(x => x.LandedDateOnly, "landed_date");
            Map(x => x.LandedTimeOnly, "landed_time");
            Map(x => x.LandedDate, "landed_dtime");
            Map(x => x.Latitude, "lat");
            Map(x => x.Longitude, "lon");
            Map(x => x.EezId, "eez_code").Length(2);
            Map(x => x.SpeciesCode, "sp_code").Length(3);
            Map(x => x.SpeciesDescription, "sp_desc");
            Map(x => x.LandedConditionCode, "landed_cond_code");
            Map(x => x.LandedConditionDescription, "landed_cond_desc");
            Map(x => x.LandedHandling, "landed_handling");
            Map(x => x.LandedLength, "landed_len").Precision(5).Scale(1);
            Map(x => x.LandedLengthCode, "len_code");
            Map(x => x.LandedSexCode, "landed_sex_code");
            Map(x => x.DiscardedConditionCode, "discard_cond_code");
            Map(x => x.DiscardedConditionDescription, "discard_cond_desc");
            Map(x => x.RetrievedTagNumber, "tag_ret_no").Length(7);
            Map(x => x.RetrievedTagType, "tag_ret_type").Length(5);
            Map(x => x.RetrievedTagOrganization, "tag_ret_org").Length(10);
            Map(x => x.PlacedTagNumber, "tag_place_no").Length(7);
            Map(x => x.PlacedTagType, "tag_place_type").Length(5);
            Map(x => x.PlacedTagOrganization, "tag_place_org").Length(10);
            Map(x => x.InteractionId, "intact_id").CustomType<InteractionActivity>();
            Map(x => x.InteractionOther, "intact_other");
            Map(x => x.InteractionDescription, "int_describe");

            Map(x => x.InteractionActivity, "sgact_id").CustomType<InteractionActivity>();
            Map(x => x.InteractionIfOther, "sgact_other");
            Map(x => x.SightingCount, "sight_n");
            Map(x => x.SightingAdultCount, "sight_adult_n");
            Map(x => x.SightingJuvenileCount, "sight_juv_n");
            Map(x => x.SightingLength, "sight_len");
            Map(x => x.SightingDistance, "sight_dist").Precision(7).Scale(3);
            Map(x => x.SightingDistanceUnit, "sight_dist_unit").CustomType<UnitOfMeasure>();
            Map(x => x.SightingDistanceInNm, "sight_dist_nm").Precision(10).Scale(4);
            Map(x => x.SightingBehavior, "sight_behav");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            HasMany(x => x.Details).KeyColumn("ssp_id");
            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
