// -----------------------------------------------------------------------
// <copyright file="PortMap.cs" company="">
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
    /// Fishing Port.  This mapping only works for largish ports
    /// that have been assigned a UN LOCODE.
    /// 
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
