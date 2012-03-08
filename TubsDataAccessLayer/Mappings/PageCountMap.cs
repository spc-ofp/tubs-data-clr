// -----------------------------------------------------------------------
// <copyright file="PageCountMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
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
    /// Fluent NHibernate mapper for purse seine activities.
    /// </summary>
    public class PageCountMap : ClassMap<PageCount>
    {
        public PageCountMap()
        {
            Schema("obsv");
            Table("page_counts");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.FormName, "form_name");
            Map(x => x.FormCount, "form_count");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");

            OptimisticLock.Version();
            Version(x => x.RowVersion).Column("tstamp").Not.Nullable().CustomSqlType("timestamp").Generated.Always();

            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
