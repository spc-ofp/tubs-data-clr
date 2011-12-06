// -----------------------------------------------------------------------
// <copyright file="ObserverMap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Spc.Ofp.Tubs.DAL.Entities;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ObserverMap : ClassMap<Observer>
    {
        public ObserverMap()
        {
            Table("[ref].[field_staff]");
            Id(x => x.StaffCode, "staff_code").GeneratedBy.Assigned();
            Map(x => x.FirstName, "first_name");
            Map(x => x.LastName, "family_name");
            HasMany(x => x.Trips).KeyColumn("staff_code").Inverse().Cascade.All();
        }
    }
}
