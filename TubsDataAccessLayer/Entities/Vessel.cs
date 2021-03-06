﻿// -----------------------------------------------------------------------
// <copyright file="Vessel.cs" company="Secretariat of the Pacific Community">
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
    using System.ComponentModel.DataAnnotations;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Vessel entity.
    /// </summary>
    public class Vessel
    {
        /// <summary>
        /// Entity primary key
        /// </summary>
        public virtual int Id { get; protected set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselTypeCode")]
        public virtual VesselTypeCode TypeCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// FFA vessel identifier (aka VID)
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "FfaVid")]
        public virtual int? FfaVid { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "WcpfcNumber")]
        public virtual string WcpfcNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Ircs")]
        public virtual string Ircs { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "RegisteredCountryCode")]
        public virtual string RegisteredCountryCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "RegistrationNumber")]
        public virtual string RegistrationNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "GrossTonnage")]
        public virtual float? GrossTonnage { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Length")]
        public virtual float? Length { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "YearBuilt")]
        public virtual int? YearBuilt { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnginePower")]
        public virtual decimal? EnginePower { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnginePowerUnits")]
        public virtual string EnginePowerUnits { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        public virtual DateTime? EnteredDate { get; set; }

        public override string ToString()
        {
            return String.IsNullOrEmpty(this.Name) ? "Unknown" : this.Name;
        }
    }
}
