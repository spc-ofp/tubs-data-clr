// -----------------------------------------------------------------------
// <copyright file="LongLineSetHaulEvent.cs" company="Secretariat of the Pacific Community">
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
    using System.ComponentModel.DataAnnotations;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LongLineSetHaulEvent
    {
        public virtual int Id { get; set; }

        public virtual LongLineSet FishingSet { get; set; }

        public virtual DateTime? LogDateOnly { get; set; }

        public virtual string LogTimeOnly { get; set; }

        public virtual DateTime? LogDate { get; set; }

        public virtual string Sethaul { get; set; }

        public virtual int? StartEndId { get; set; }

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

        [Range(0, 360)]
        [Display(ResourceType = typeof(FieldNames), Name = "WindDirection")]
        public virtual int? WindDirection { get; set; }

        [Range(0, Int32.MaxValue)]
        [Display(ResourceType = typeof(FieldNames), Name = "WindSpeed")]
        public virtual int? WindSpeed { get; set; }

        [EnumDataType(typeof(SeaCode))]
        [Display(ResourceType = typeof(FieldNames), Name = "SeaCode")]
        public virtual SeaCode? SeaCode { get; set; }

        public virtual int? CloudCover { get; set; }

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
    }
}
