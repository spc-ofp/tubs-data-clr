// -----------------------------------------------------------------------
// <copyright file="VesselMap.cs" company="">
// TODO: Update copyright text.
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
