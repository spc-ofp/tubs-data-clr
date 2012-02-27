// -----------------------------------------------------------------------
// <copyright file="CommunicationServicesMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the CommunicationServices entity.
    /// </summary>
    public sealed class CommunicationServicesMap : ClassMap<CommunicationServices>
    {
        public CommunicationServicesMap()
        {
            Schema("obsv");
            Table("vess_electronics");
            Id(x => x.Id, "vess_elect_id").GeneratedBy.Identity();
            Map(x => x.HasSatellitePhone, "satphone_yn").CustomType(typeof(YesNoType));
            Map(x => x.SatellitePhoneNumber, "satphone_number");
            Map(x => x.HasMobilePhone, "mobphone_yn").CustomType(typeof(YesNoType));
            Map(x => x.MobilePhoneNumber, "mobphone_number");
            Map(x => x.HasFax, "fax_yn").CustomType(typeof(YesNoType));
            Map(x => x.FaxNumber, "fax_number");
            Map(x => x.HasEmail, "email_yn").CustomType(typeof(YesNoType));
            Map(x => x.EmailAddress, "email_address");
            Map(x => x.HasWeatherFax, "weatherfax_yn").CustomType(typeof(YesNoType));
            Map(x => x.HasSatelliteMonitor, "satmonitor_yn").CustomType(typeof(YesNoType));
            Map(x => x.HasOther, "other_yn").CustomType(typeof(YesNoType));
            Map(x => x.HasPhytoplanktonService, "phyto_yn").CustomType(typeof(YesNoType));
            Map(x => x.PhytoplanktonUrl, "phyto_url");
            Map(x => x.HasSeaSurfaceTemperatureService, "sst_yn").CustomType(typeof(YesNoType));
            Map(x => x.SeaSurfaceTemperatureUrl, "sst_url");
            Map(x => x.HasSeaHeightService, "seaheight_yn").CustomType(typeof(YesNoType));
            Map(x => x.SeaHeightServiceUrl, "seaheight_url");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
