// -----------------------------------------------------------------------
// <copyright file="SpecialSpeciesInteraction.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SpecialSpeciesInteraction
    {
        public SpecialSpeciesInteraction()
        {
            this.Details = new List<InteractionDetail>();
        }

        public virtual int Id { get; protected set; }

        public virtual Trip Trip { get; set; }

        public virtual string SgType { get; set; } // ???

        public virtual string SgTime { get; set; }

        public virtual DateTime? LandedDateOnly { get; set; }

        public virtual string LandedTimeOnly { get; set; }

        public virtual DateTime? LandedDate { get; set; }

        public virtual string Latitude { get; set; }

        public virtual string Longitude { get; set; }

        public virtual string EezId { get; set; }

        public virtual string SpeciesCode { get; set; }

        public virtual string SpeciesDescription { get; set; }

        public virtual ConditionCode? LandedConditionCode { get; set; }

        public virtual string LandedConditionDescription { get; set; }

        public virtual string LandedHandling { get; set; }

        public virtual decimal? LandedLength { get; set; }

        public virtual LengthCode? LandedLengthCode { get; set; }

        public virtual SexCode? LandedSexCode { get; set; }

        public virtual ConditionCode? DiscardedConditionCode { get; set; }

        public virtual string DiscardedConditionDescription { get; set; }

        public virtual string TagReturnNumber { get; set; }

        public virtual string TagReturnType { get; set; }

        public virtual string TagReturnOrganization { get; set; }

        public virtual string TagPlacedNumber { get; set; }

        public virtual string TagPlacedType { get; set; }

        public virtual string TagPlacedOrganization { get; set; }

        public virtual string InteractionId { get; set; }

        public virtual string InteractionOther { get; set; }

        public virtual string InteractionDescription { get; set; }

        public virtual char SgActId { get; set; } // See what happens as char

        public virtual string SgActOther { get; set; }

        public virtual int? SightingCount { get; set; }

        public virtual int? SightingAdultCount { get; set; }

        public virtual int? SightingJuvenileCount { get; set; }

        public virtual string SightingLength { get; set; }

        public virtual decimal? SightingDistance { get; set; }

        public virtual string SightingDistanceUnit { get; set; }

        public virtual decimal SightingDistanceInNm { get; set; }

        public virtual string SightingBehavior { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }

        public virtual IList<InteractionDetail> Details { get; protected internal set; }

        public virtual void AddDetail(InteractionDetail detail)
        {
            detail.Header = this;
            this.Details.Add(detail);
        }
    }
}
