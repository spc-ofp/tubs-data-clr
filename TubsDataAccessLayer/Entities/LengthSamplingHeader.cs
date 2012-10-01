// -----------------------------------------------------------------------
// <copyright file="LengthSamplingHeader.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LengthSamplingHeader : IAuditable
    {
        public LengthSamplingHeader()
        {
            this.Samples = new List<LengthSample>();
            this.Brails = new List<Brail>();
        }

        public virtual int Id { get; set; }

        public virtual int? FormId { get; set; }

        [EnumDataType(typeof(SamplingProtocol))]
        public virtual SamplingProtocol? SamplingProtocol { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public virtual string SamplingProtocolComments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "BrailStartTime")]
        public virtual string BrailStartTime { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "BrailEndTime")]
        public virtual string BrailEndTime { get; set; }

        /// <summary>
        /// Gets or sets the brail used.  Typical purse seine vessels have
        /// two brails, so if present this should be either '1' or '2'
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "BrailNumber")]
        [RangeAttribute(1, 2)]
        public virtual int? BrailNumber { get; set; }

        // For spill sampling only
        [Display(ResourceType = typeof(FieldNames), Name = "SampledBrailNumber")]
        public virtual int? SampledBrailNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "NumberOfFishMeasured")]
        public virtual int? NumberOfFishMeasured { get; set; }

        // All sampling protocols
        [Display(ResourceType = typeof(FieldNames), Name = "CalibratedThisSet")]
        public virtual bool? CalibratedThisSet { get; set; }

        /// <summary>
        /// Gets or sets the page number within the set of pages
        /// recording brailing for the associated set.
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "PageNumber")]
        [Range(1, Int32.MaxValue)]
        public virtual int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages recording
        /// brailing for the associated set.
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "PageCount")]
        [Range(0, Int32.MaxValue)]
        public virtual int? PageCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "FishPerBrail")]
        [Range(0, Int32.MaxValue)]
        public virtual int? FishPerBrail { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "MeasuringInstrument")]
        public virtual string MeasuringInstrument { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "FullBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? FullBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SevenEighthsBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SevenEighthsBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ThreeQuartersBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? ThreeQuartersBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TwoThirdsBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? TwoThirdsBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "OneHalfBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? OneHalfBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "OneThirdBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? OneThirdBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "OneQuarterBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? OneQuarterBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "OneEighthBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? OneEighthBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TotalBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? TotalBrailCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SumOfAllBrails")]
        public virtual decimal? SumOfAllBrails { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
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

        public virtual PurseSeineSet Set { get; set; }

        public virtual IList<LengthSample> Samples { get; protected internal set; }

        public virtual IList<Brail> Brails { get; protected internal set; }

        public virtual void AddLengthSample(LengthSample sample)
        {
            if (null == sample)
                return;

            sample.Header = this;
            this.Samples.Add(sample);
        }

        public virtual void AddBrail(Brail brail)
        {
            if (null == brail)
                return;
            
            brail.Header = this;
            this.Brails.Add(brail);
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
