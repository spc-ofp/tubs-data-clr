﻿// -----------------------------------------------------------------------
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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Entity that collects vessel information specific to Purse Seiners.
    /// </summary>
    public class PurseSeineVesselAttributes : IAuditable, IEntity
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SpeedboatCount")]
        [Range(0d, 100d)]
        public virtual int? SpeedboatCount { get; set; }

        [Range(0d, 100d)]
        public virtual int? TowboatCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "AuxiliaryBoatCount")]
        [Range(0d, 100d)]
        public virtual int? AuxiliaryBoatCount { get; set; }

        public virtual int? LightCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HasTenderBoats")]
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

        public virtual UnitOfMeasure? HelicopterRangeUnit { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HelicopterColor")]
        public virtual string HelicopterColor { get; set; }

        /// <summary>
        /// Gets or sets the count of other vessels serviced by this helicopter.
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "HelicopterServiceOtherCount")]
        public virtual int? HelicopterServiceOtherCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselLength")]
        public virtual int? VesselLength { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselLengthUnits")]
        public virtual UnitOfMeasure? VesselLengthUnits { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselTonnage")]
        public virtual int? VesselTonnage { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        public virtual DateTime? EnteredDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UpdatedBy")]
        public virtual string UpdatedBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UpdatedDate")]
        public virtual DateTime? UpdatedDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DctNotes")]
        [DataType(DataType.MultilineText)]
        public virtual string DctNotes { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DctScore")]
        public virtual int? DctScore { get; set; }

        public virtual bool IsNew()
        {
            return default(int) == this.Id;
        }

        public virtual object GetPkid()
        {
            return this.Id;
        }

        public virtual void SetAuditTrail(string userName, DateTime timestamp)
        {
            if (default(int) == this.Id)
            {
                this.EnteredBy = userName;
                this.EnteredDate = timestamp;
            }
            else
            {
                this.UpdatedBy = userName;
                this.UpdatedDate = timestamp;
            }
        }
    }
}
