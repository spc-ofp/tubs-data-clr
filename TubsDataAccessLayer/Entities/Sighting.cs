﻿// -----------------------------------------------------------------------
// <copyright file="Sighting.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Sighting represents a vessel sighting recorded on form GEN-1.
    /// </summary>
    public class Sighting : IAuditable, IEntity /*, ISecurable*/
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual int? FormId { get; set; }

        public virtual DateTime? EventDateOnly { get; set; }

        public virtual string EventTimeOnly { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LocalTime")]
        public virtual DateTime? EventDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Latitude")]
        [RegularExpression(@"^[0-8]\d{3}\.?\d{3}[NnSs]$", 
            ErrorMessageResourceType = typeof(ErrorMessages), 
            ErrorMessageResourceName= "LatitudeError")]
        public virtual string Latitude { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Longitude")]
        [RegularExpression(@"^[0-1]\d{4}\.?\d{3}[EeWw]$",
            ErrorMessageResourceType = typeof(ErrorMessages), 
            ErrorMessageResourceName= "LongitudeError")]
        public virtual string Longitude { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EezId")]
        public virtual string EezCode { get; set; }

        public virtual Vessel Vessel { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselName")]
        public virtual string VesselName { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Ircs")]
        public virtual string Ircs { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselFlag")]
        public virtual string VesselFlag { get; set; }

        //Vessel Type
        [Display(ResourceType = typeof(FieldNames), Name = "VesselType")]
        [EnumDataType(typeof(SightedVesselType))]
        public virtual SightedVesselType? VesselType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Bearing")]
        [Range(0d, 360d)]
        public virtual int? Bearing { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Distance")]
        [Range(0.0d, Double.MaxValue)]
        public virtual decimal? Distance { get; set; }

        // FIXME This needs to be a link to one of the unit1/unit4 values :(
        public virtual string DistanceUnit { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ActionType")]
        [EnumDataType(typeof(ActionType))]
        public virtual ActionType? ActionType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "PhotoNumber")]
        public virtual string PhotoNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public virtual string Comments { get; set; }

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

        public virtual DateTime? GetDate()
        {
            return this.EventDate.HasValue ?
                this.EventDate :
                this.EventDateOnly.Merge(this.EventTimeOnly);
        }

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
