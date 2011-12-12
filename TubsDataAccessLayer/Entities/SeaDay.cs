// -----------------------------------------------------------------------
// <copyright file="SeaDay.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Tubs.DAL.Entities
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class SeaDay
    {
        public virtual int Id { get; private set; }

        public virtual Trip Trip { get; set; }

        public virtual int? FormId { get; set; }

        public virtual DateTime? StartOfDay { get; set; }

        public virtual DateTime? UtcStartOfDay { get; set; }

        public virtual int? FloatingObjectsNoSchool { get; set; }

        public virtual int? FloatingObjectsWithSchool { get; set; }

        public virtual int? FadsNoSchool { get; set; }

        public virtual int? FadsWithSchool { get; set; }

        public virtual int? FreeSchools { get; set; }

        public virtual bool? Gen3Events { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }
    }
}
