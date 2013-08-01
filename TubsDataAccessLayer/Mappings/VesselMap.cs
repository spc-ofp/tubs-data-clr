// -----------------------------------------------------------------------
// <copyright file="VesselMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the Vessel entity.
    /// </summary>
    public sealed class VesselMap : ClassMap<Vessel>
    {
        public VesselMap()
        {
            ReadOnly();
            Schema("ref");
            Table("vessels");
            Id(x => x.Id, "vessel_id").GeneratedBy.Identity();
            Map(x => x.TypeCode, "vty_code");
            Map(x => x.Name, "vessel_name").Length(50);
            Map(x => x.FfaVid, "ffa_id");
            Map(x => x.WcpfcNumber, "wcpfc_number").Length(50);
            Map(x => x.Ircs, "ircs").Length(16);
            Map(x => x.RegisteredCountryCode, "reg_country_code").Length(2);
            Map(x => x.RegistrationNumber, "reg_number").Length(20);
            Map(x => x.GrossTonnage, "grt");
            Map(x => x.Length, "length");
            Map(x => x.YearBuilt, "year_built");
            Map(x => x.EnginePower, "engine_power");
            Map(x => x.EnginePowerUnits, "power_units").Length(2);
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
        }
    }
}
