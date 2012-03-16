// -----------------------------------------------------------------------
// <copyright file="TransferMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the Transfer entity.
    /// </summary>
    public sealed class TransferMap : ClassMap<Transfer>
    {
        public TransferMap()
        {
            Schema("obsv");
            Table("gen1fishtransfer");
            Id(x => x.Id, "fish_tran_id").GeneratedBy.Identity();
            Map(x => x.TransferTime, "fish_tran_dtime");
            Map(x => x.Latitude, "lat").Length(9);
            Map(x => x.Longitude, "lon").Length(10);
            Map(x => x.EezCode, "eez_code").Length(2);
            Map(x => x.VesselType, "vatyp_id").CustomType(typeof(VesselType));
            Map(x => x.VesselName, "vessel_name").Length(50);
            Map(x => x.VesselFlag, "reg_country_code").Length(2);
            Map(x => x.Ircs, "ircs").Length(16);
            Map(x => x.TonsOfSkipjack, "skj_c");
            Map(x => x.TonsOfYellowfin, "yft_c");
            Map(x => x.TonsOfBigeye, "bet_c");
            Map(x => x.TonsOfMixed, "mix_c");
            Map(x => x.ActionType, "action_code");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.Vessel).Column("vessel_id");
            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
