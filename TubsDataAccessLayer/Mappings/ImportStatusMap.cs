// -----------------------------------------------------------------------
// <copyright file="ImportStatusMap.cs" company="Secretariat of the Pacific Community">
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
    using System;
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Fluent NHibernate mapping for the ImportStatus entity.
    /// </summary>
    public sealed class ImportStatusMap : ClassMap<ImportStatus>
    {
        public ImportStatusMap()
        {
            Schema("obsv");
            Table("import_status");
            Id(x => x.Id, "id");
            Map(x => x.SourceId, "source_id");
            Map(x => x.SourceName, "source_name");
            Map(x => x.TripId, "obstrip_id");
            Map(x => x.StatusCode, "status");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");

            // Although this mapping could reference the trip, that's not necessary
            // Importing is orthagonal to displaying the full entity collection for a trip
            // If we want to see the imported trip, using TripId to construct a URL is just fine
        }
    }
}
