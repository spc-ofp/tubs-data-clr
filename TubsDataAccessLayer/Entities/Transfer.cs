// -----------------------------------------------------------------------
// <copyright file="Transfer.cs" company="Secretariat of the Pacific Community">
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
    /// TODO: Update summary.
    /// </summary>
    public class Transfer
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LocalTime")]
        public virtual DateTime? TransferTime { get; set; }

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

        public virtual Vessel Vessel { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselName")]
        public virtual string VesselName { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Ircs")]
        public virtual string Ircs { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselFlag")]
        public virtual string VesselFlag { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VesselType")]
        [EnumDataType(typeof(VesselType))]
        public virtual VesselType? VesselType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TonsOfSkipjack")]
        public virtual decimal? TonsOfSkipjack { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TonsOfYellowfin")]
        public virtual decimal? TonsOfYellowfin { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TonsOfBigeye")]
        public virtual decimal? TonsOfBigeye { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TonsOfMixed")]
        public virtual decimal? TonsOfMixed { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HostActionCode")]
        [EnumDataType(typeof(ActionType))]
        public virtual ActionType? ActionType { get; set; }

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
    }
}
