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
    /// PS-4 header entity.
    /// </summary>
    public class LengthSamplingHeader : IAuditable, IEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LengthSamplingHeader()
        {
            this.Samples = new List<LengthSample>();
        }

        /// <summary>
        /// Entity primary key
        /// </summary>
        public virtual int Id { get; set; }

        public virtual int? FormId { get; set; }

        [EnumDataType(typeof(SamplingProtocol))]
        public virtual SamplingProtocol? SamplingProtocol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// The v2009 form adds a field for 'Other' sampling protocols
        /// complete with a code 
        /// </remarks>
        public virtual string OtherSamplingCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public virtual string SamplingProtocolComments { get; set; }

        /// <summary>
        /// Gets or sets the brail used.  Typical purse seine vessels have
        /// two brails, so if present this should be either '1' or '2'
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "BrailNumber")]
        [RangeAttribute(1, 2)]
        public virtual int? BrailNumber { get; set; }

        /// <summary>
        /// Gets or sets which brail (sequence) was sampled.  Spill sampling only.
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "SampledBrailNumber")]
        public virtual int? SampledBrailNumber { get; set; }

        /// <summary>
        /// Gets or sets the count of fish measured.  Spill sampling only.
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "NumberOfFishMeasured")]
        public virtual int? NumberOfFishMeasured { get; set; }

        /// <summary>
        /// Gets or sets whether the measuring instrument was calibrated for this set.
        /// </summary>
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

        /// <summary>
        /// The Brail object contains the 30 brail samples, while a single
        /// PS-4 form can only record the results from 30 brails.
        /// Originally, this was a collection that contained either zero or one
        /// Brail object.
        /// </summary>
        public virtual Brail Brails { get; set; }

        /// <summary>
        /// Gets or sets the target number of fish sampled per brail.
        /// Grab sampling only, this is usually 5.
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "FishPerBrail")]
        [Range(0, Int32.MaxValue)]
        public virtual int? FishPerBrail { get; set; }

        // TODO: Convert this to an enumeration
        [Display(ResourceType = typeof(FieldNames), Name = "MeasuringInstrument")]
        public virtual string MeasuringInstrument { get; set; }

        /// <summary>
        /// Gets or sets the number of full brails brought onboard during this set.
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "FullBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? FullBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the number of 7/8 full brails brought onboard during this set. 
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "SevenEighthsBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SevenEighthsBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the number of 3/4 full brails brought onboard during this set. 
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "ThreeQuartersBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? ThreeQuartersBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the number of 2/3 full brails brought onboard during this set. 
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "TwoThirdsBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? TwoThirdsBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the number of 1/2 full brails brought onboard during this set. 
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "OneHalfBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? OneHalfBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the number of 1/3 full brails brought onboard during this set. 
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "OneThirdBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? OneThirdBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the number of 1/4 full brails brought onboard during this set. 
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "OneQuarterBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? OneQuarterBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the number of 1/8 full brails brought onboard during this set. 
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "OneEighthBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? OneEighthBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of brails brought onboard during this set. 
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "TotalBrailCount")]
        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? TotalBrailCount { get; set; }

        /// <summary>
        /// Gets or sets the sum of normalized brail contents. 
        /// </summary>
        /// <remarks>
        /// One full brail plus one half-full brail plus 2 quarter-full brails
        /// would be 2.
        /// </remarks>
        [Display(ResourceType = typeof(FieldNames), Name = "SumOfAllBrails")]
        public virtual decimal? SumOfAllBrails { get; set; }

        /// <summary>
        /// Gets or sets comments associated with this entity. 
        /// </summary>
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

        public virtual void AddLengthSample(LengthSample sample)
        {
            if (null == sample)
                return;

            sample.Header = this;
            this.Samples.Add(sample);
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
