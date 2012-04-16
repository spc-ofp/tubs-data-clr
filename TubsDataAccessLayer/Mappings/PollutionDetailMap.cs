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
    public class PollutionDetailMap : ClassMap<PollutionDetail>
    {
        public PollutionDetailMap()
        {
            Schema("obsv");
            Table("gen6polldetails");
            Id(x => x.Id, "pollutiondetails_id").GeneratedBy.Identity();            
            Map(x => x.Description, "poll_desc");
            Map(x => x.Quantity, "poll_qty");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            References(x => x.Header).Column("pollution_id").Not.Nullable();
            DiscriminateSubClassesOnColumn("pollutiontype_id");
        }
    }

    /// <summary>
    /// Mapping for GEN-6 spill details.
    /// </summary>
    public sealed class SpillDetailMap : SubclassMap<SpillDetail>
    {
        public SpillDetailMap()
        {
            DiscriminatorValue((int)PollutionType.SpillageOrLeakage);
            Map(x => x.Source, "material_id").CustomType<SpillSource>();
            // FIXME The form has a textbox for recording other that's not present in the database
        }
    }

    /// <summary>
    /// Mapping for GEN-6 waste details.
    /// </summary>
    public sealed class WasteDetailMap : SubclassMap<WasteDetail>
    {
        public WasteDetailMap()
        {
            DiscriminatorValue((int)PollutionType.DumpedOverboard);
            Map(x => x.Material, "material_id").CustomType<PollutionMaterial>();
        }
    }
}
