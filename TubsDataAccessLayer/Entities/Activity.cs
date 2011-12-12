// -----------------------------------------------------------------------
// <copyright file="Activity.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Activity represents a line item on the daily log form
    /// (e.g. PS-2 for purse seine trips, not sure what it is for
    /// pole and line trips...)
    /// </summary>
    public abstract class Activity
    {
        public virtual int Id { get; private set; }
        
        public virtual DateTime? LocalTime { get; set; }

        public virtual DateTime? UtcTime { get; set; } // Derived from UTC offset of local time

        public virtual string Latitude { get; set; }

        public virtual string Longitude { get; set; }

        public virtual string EezCode { get; set; }

        public virtual ActivityType? ActivityType { get; set; }

        public virtual SchoolAssociation? SchoolAssociation { get; set; }

        public virtual DetectionMethod? DetectionMethod { get; set; }

        public virtual string Beacon { get; set; }

        public virtual string Comments { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }
    }
}
