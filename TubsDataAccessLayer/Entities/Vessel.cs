// -----------------------------------------------------------------------
// <copyright file="Vessel.cs" company="Secretariat of the Pacific Community">
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
    /// TODO: Update summary.
    /// </summary>
    public class Vessel
    {
        public virtual int Id { get; private set; }
        public virtual string TypeCode { get; set; } // TODO Enum?
        public virtual string Name { get; set; }
        public virtual string WcpfcNumber { get; set; }
        public virtual string Ircs { get; set; }
        public virtual string RegisteredCountryCode { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual float? GrossTonnage { get; set; }
        public virtual float? Length { get; set; }
        public virtual int? YearBuilt { get; set; }
        public virtual decimal? EnginePower { get; set; }
        public virtual string EnginePowerUnits { get; set; }

        // Audit trail
        public virtual string EnteredBy { get; set; }
        public virtual DateTime? EnteredDate { get; set; }
    }
}
