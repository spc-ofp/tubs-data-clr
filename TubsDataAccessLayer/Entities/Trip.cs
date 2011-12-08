// -----------------------------------------------------------------------
// <copyright file="Trip.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// 
// This file is part of TUBS.
// 
//  TUBS is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// TUBS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Generic trip representation.
    /// </summary>
    public abstract class Trip
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime? DepartureDate { get; set; }
        public virtual DateTime? UtcDepartureDate { get; set; }
        public virtual DateTime? ReturnDate { get; set; }
        public virtual string TripNumber { get; set; }

        public virtual Vessel Vessel { get; set; }
        public virtual Observer Observer { get; set; }

        public virtual Port DeparturePort { get; set; }
        public virtual Port ReturnPort { get; set; }

        // Audit trail
        public virtual string EnteredBy { get; set; }
        public virtual DateTime? EnteredDate { get; set; }

        // Trip knows how to create it's own metrics
        // TODO Implement!  This is here as a reminder on how to implement the API
        public virtual object CatchAndEffort { get; protected set; }
    }
}
