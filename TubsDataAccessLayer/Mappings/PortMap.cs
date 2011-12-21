// -----------------------------------------------------------------------
// <copyright file="PortMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fishing Port.  This mapping only works for largish ports
    /// that have been assigned a UN LOCODE.
    /// </summary>
    public class PortMap : ClassMap<Port>
    {
        public PortMap()
        {
            Table("[ref].[ports]");
            Id(x => x.PortCode, "location_code").GeneratedBy.Assigned();
            Map(x => x.Name, "port_name");
            Map(x => x.AlternateName, "alsocalled");
            Map(x => x.CountryCode, "country_code");
            Map(x => x.Latitude, "port_lat");
            Map(x => x.Longitude, "port_lon");
        }
    }
}
