// -----------------------------------------------------------------------
// <copyright file="PurseSeineWellContentMap.cs" company="">
// TODO: Update copyright text.
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
    /// Fluent NHibernate mapping for the PurseSeineWellContent entity.
    /// </summary>
    public sealed class PurseSeineWellContentMap : ClassMap<PurseSeineWellContent>
    {
        public PurseSeineWellContentMap()
        {
            Schema("obsv");
            Table("s_wellcontent");
            Id(x => x.Id, "wc_id").GeneratedBy.Identity();
            Map(x => x.FuelOrWater, "fuel_water").CustomType<WellContentType>();
            Map(x => x.WellNumber, "well_number");
            Map(x => x.WellLocation, "ps");
            Map(x => x.WellCapacity, "well_capacity").Precision(6).Scale(2);
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
