// -----------------------------------------------------------------------
// <copyright file="PollutionDetailMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
{
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Fluent NHibernate mapping for the PollutionDetail entity.
    /// </summary>
    public sealed class PollutionDetailMap : ClassMap<PollutionDetail>
    {
        public PollutionDetailMap()
        {
            Table("obsv.gen6polldetails");
            Id(x => x.Id, "pollutiondetails_id").GeneratedBy.Identity();
            Map(x => x.PollutionType, "pollutiontype_id").CustomType(typeof(PollutionType));
            Map(x => x.Material, "material_id").CustomType(typeof(PollutionMaterial));
            Map(x => x.Description, "poll_desc");
            Map(x => x.Quantity, "poll_qty");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Header).Column("pollution_id");
        }
    }
}
