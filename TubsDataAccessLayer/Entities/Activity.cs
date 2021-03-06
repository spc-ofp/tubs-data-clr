﻿// -----------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Activity represents a line item on the daily log form
    /// (e.g. PS-2 for purse seine trips, not sure what it is for
    /// pole and line trips...)
    /// </summary>
    public abstract class Activity : IAuditable, IEntity /*, ISecurable*/
    {
        public virtual int Id { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LocalTime")]
        public virtual DateTime? LocalTime { get; set; }

        public virtual DateTime? LocalTimeDateOnly { get; set; }

        // Yes, this is a crappy variable name, but it should be
        // understood as Local Time, time only
        public virtual string LocalTimeTimeOnly { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UtcTime")]
        public virtual DateTime? UtcTime { get; set; } // Derived from UTC offset of local time

        public virtual DateTime? UtcDateOnly { get; set; }

        public virtual string UtcTimeOnly { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Latitude")]
        [RegularExpression(@"^[0-8]\d{3}\.?\d{3}[NnSs]$",
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "LatitudeError")]
        public virtual string Latitude { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Longitude")]
        [RegularExpression(@"^[0-1]\d{4}\.?\d{3}[EeWw]$",
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "LongitudeError")]
        public virtual string Longitude { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EezId")]
        public virtual string EezCode { get; set; }

        public virtual ActivityType? ActivityType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SchoolAssociation")]
        [EnumDataType(typeof(SchoolAssociation))]
        public virtual SchoolAssociation? SchoolAssociation { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DetectionMethod")]
        [EnumDataType(typeof(DetectionMethod))]
        public virtual DetectionMethod? DetectionMethod { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Beacon")]
        public virtual string Beacon { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public virtual string Comments { get; set; }

        public virtual byte[] RowVersion { get; protected internal set; }

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
