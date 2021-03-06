﻿// -----------------------------------------------------------------------
// <copyright file="TripHeaderMap.cs" company="">
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
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Fluent NHibernate mapping for the TripHeader entity.
    /// </summary>
    public sealed class TripHeaderMap : ClassMap<TripHeader>
    {
        public TripHeaderMap()
        {
            ReadOnly();
            Schema("obsv");
            Table("trip");
            Id(x => x.Id, "obstrip_id").GeneratedBy.Identity();
            Map(x => x.ProgramCode, "obsprg_code");
            Map(x => x.TripNumber, "tripno");
            Map(x => x.DeparturePort, "dep_port");
            Map(x => x.ReturnPort, "ret_port");
            Map(x => x.Version, "versn_id").CustomType(typeof(WorkbookVersion));
            Map(x => x.DepartureDate, "dep_date");
            Map(x => x.ReturnDate, "ret_date");
            Map(x => x.GearCode, "gear_code");
            Map(x => x.CkTripNumber, "tripno_ck");
            Map(x => x.FmTripNumber, "tripno_fm");
            Map(x => x.FfaTripNumber, "tripno_ffa");
            Map(x => x.SbTripNumber, "tripno_sb");
            Map(x => x.HwTripNumber, "tripno_hw");
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.ClosedDate, "closed_date");

            References(x => x.Vessel).Column("vessel_id").Not.LazyLoad();
            References(x => x.Observer).Column("staff_code").Not.LazyLoad();

            ApplyFilter<ProgramCodeFilter>();
        }
    }
}
