// -----------------------------------------------------------------------
// <copyright file="PurseSeineVesselAttributes.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
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

    /// <summary>
    /// Entity that collects vessel information specific to Purse Seiners.
    /// </summary>
    public class PurseSeineVesselAttributes
    {
        public virtual int Id { get; protected set; }

        public virtual Trip Trip { get; set; }

        public virtual int? SpeedboatCount { get; set; }

        public virtual int? TowboatCount { get; set; }

        public virtual int? AuxiliaryBoatCount { get; set; }

        public virtual int? LightCount { get; set; }

        public virtual bool? HasTenderBoats { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SkiffMake")]
        public virtual string SkiffMake { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SkiffPower")]
        public virtual int? SkiffPower { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "CruiseSpeed")]
        public virtual decimal? CruiseSpeed { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HelicopterMake")]
        public virtual string HelicopterMake { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HelicopterModel")]
        public virtual string HelicopterModel { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HelicopterRegistration")]
        public virtual string HelicopterRegistrationNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HelicopterRange")]
        public virtual int? HelicopterRange { get; set; }

        public virtual int? HelicopterRangeUnit { get; set; } // Enum

        [Display(ResourceType = typeof(FieldNames), Name = "HelicopterColor")]
        public virtual string HelicopterColor { get; set; }

        /// <summary>
        /// Gets or sets the count of other vessels serviced by this helicopter.
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "HelicopterServiceOtherCount")]
        public virtual int? HelicopterServiceOtherCount { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }
    }
}
