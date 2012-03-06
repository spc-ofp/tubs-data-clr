// -----------------------------------------------------------------------
// <copyright file="SpecialSpeciesInteraction.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Entity representing interactions with species of special interest.
    /// Data are collected on GEN-2 forms.
    /// </summary>
    public class SpecialSpeciesInteraction
    {
        public SpecialSpeciesInteraction()
        {
            this.Details = new List<InteractionDetail>();
        }

        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual string SgType { get; set; }

        public virtual string SgTime { get; set; }

        public virtual DateTime? LandedDateOnly { get; set; }

        public virtual string LandedTimeOnly { get; set; }

        public virtual DateTime? LandedDate { get; set; }

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
        public virtual string EezId { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SpeciesCode")]
        public virtual string SpeciesCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SpeciesDescription")]
        public virtual string SpeciesDescription { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ConditionCode")]
        public virtual ConditionCode? LandedConditionCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ConditionDescription")]
        public virtual string LandedConditionDescription { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LandedHandling")]
        public virtual string LandedHandling { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Length")]
        public virtual decimal? LandedLength { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LengthCode")]
        public virtual LengthCode? LandedLengthCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SexCode")]
        public virtual SexCode? LandedSexCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ConditionCode")]
        public virtual ConditionCode? DiscardedConditionCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ConditionDescription")]
        public virtual string DiscardedConditionDescription { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagNumber")]
        public virtual string TagReturnNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagType")]
        public virtual string TagReturnType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagOrg")]
        public virtual string TagReturnOrganization { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagNumber")]
        public virtual string TagPlacedNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagType")]
        public virtual string TagPlacedType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagOrg")]
        public virtual string TagPlacedOrganization { get; set; }

        public virtual InteractionActivity? InteractionId { get; set; }

        public virtual string InteractionOther { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Description")]
        public virtual string InteractionDescription { get; set; }

        public virtual InteractionActivity? InteractionActivity { get; set; }

        public virtual string InteractionIfOther { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingCount")]
        public virtual int? SightingCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingAdultCount")]
        public virtual int? SightingAdultCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingJuvenileCount")]
        public virtual int? SightingJuvenileCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingLength")]
        public virtual string SightingLength { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingDistance")]
        public virtual decimal? SightingDistance { get; set; }

        public virtual UnitOfMeasure? SightingDistanceUnit { get; set; }

        public virtual decimal SightingDistanceInNm { get; set; }

        public virtual string SightingBehavior { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        public virtual DateTime? EnteredDate { get; set; }

        public virtual IList<InteractionDetail> Details { get; protected internal set; }

        public virtual void AddDetail(InteractionDetail detail)
        {
            detail.Header = this;
            this.Details.Add(detail);
        }
    }
}
