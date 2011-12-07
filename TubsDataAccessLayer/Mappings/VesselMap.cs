// -----------------------------------------------------------------------
// <copyright file="VesselMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// 
// This file is part of TUBS.
// 
//  TUBS is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// TUBS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VesselMap : ClassMap<Vessel>
    {
        public VesselMap()
        {
            Table("[ref].[vessels]");
            Id(x => x.Id, "vessel_id").GeneratedBy.Identity();
            Map(x => x.TypeCode, "vty_code");
            Map(x => x.Name, "vessel_name");
            Map(x => x.WcpfcNumber, "wcpfc_number");
            Map(x => x.Ircs, "ircs");
            Map(x => x.RegisteredCountryCode, "reg_country_code");
            Map(x => x.RegistrationNumber, "reg_number");
            Map(x => x.GrossTonnage, "grt");
            Map(x => x.Length, "length");
            Map(x => x.YearBuilt, "year_built");
            Map(x => x.EnginePower, "engine_power");
            Map(x => x.EnginePowerUnits, "power_units");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
        }
    }
}
