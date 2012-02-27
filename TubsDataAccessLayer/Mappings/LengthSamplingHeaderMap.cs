// -----------------------------------------------------------------------
// <copyright file="LengthSamplingHeaderMap.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Fluent NHibernate mapping for the LengthSamplingHeader entity.
    /// </summary>
    public sealed class LengthSamplingHeaderMap : ClassMap<LengthSamplingHeader>
    {
        public LengthSamplingHeaderMap()
        {
            Schema("obsv");
            Table("s_lf");
            Id(x => x.Id, "s_lf_id").GeneratedBy.Identity();
            Map(x => x.FormId, "form_id");
            Map(x => x.SamplingProtocol, "sampletype_id").CustomType(typeof(SamplingProtocol));
            Map(x => x.SamplingProtocolComments, "other_desc");
            Map(x => x.BrailStartTime, "sbrail_time");
            Map(x => x.BrailEndTime, "ebrail_time");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Set).Column("s_set_id");
            HasMany(x => x.Samples).KeyColumn("s_lf_id").Cascade.All();
            HasMany(x => x.Brails).KeyColumn("s_lf_id").Cascade.All();
        }
    }
}
