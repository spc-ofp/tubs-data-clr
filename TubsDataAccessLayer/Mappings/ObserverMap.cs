// -----------------------------------------------------------------------
// <copyright file="ObserverMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the Observer entity.
    /// </summary>
    public sealed class ObserverMap : ClassMap<Observer>
    {
        public ObserverMap()
        {
            ReadOnly();
            Schema("ref");
            Table("field_staff");
            Id(x => x.StaffCode, "staff_code").GeneratedBy.Assigned();
            Map(x => x.FirstName, "first_name");
            Map(x => x.LastName, "family_name");
            HasMany(x => x.Trips).KeyColumn("staff_code").Inverse().Cascade.All();
        }
    }
}
