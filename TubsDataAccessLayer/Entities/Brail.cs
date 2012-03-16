// -----------------------------------------------------------------------
// <copyright file="Brail.cs" company="Secretariat of the Pacific Community">
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
    public class Brail
    {
        /// <summary>
        /// Gets or sets unique entity identifier
        /// </summary>
        [Key]
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the brail used.  Typical purse seine vessels have
        /// two brails, so if present this should be either '1' or '2'
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "BrailNumber")]
        [RangeAttribute(1,2)]
        public virtual int? BrailNumber { get; set; }

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

        [Display(ResourceType = typeof(FieldNames), Name = "LengthCode")]
        [EnumDataType(typeof(LengthCode))]
        public virtual LengthCode? LengthCode { get; set; }

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

        //// Long term, this needs to be fixed by moving it out to another table
        [RangeAttribute(1, 8)]
        public virtual int? Brail1FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail1 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail2FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail2 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail3FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail3 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail4FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail4 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail5FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail5 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail6FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail6 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail7FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail7 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail8FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail8 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail9FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail9 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail10FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail10 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail11FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail11 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail12FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail12 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail13FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail13 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail14FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail14 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail15FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail15 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail16FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail16 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail17FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail17 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail18FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail18 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail19FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail19 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail20FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail20 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail21FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail21 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail22FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail22 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail23FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail23 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail24FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail24 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail25FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail25 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail26FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail26 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail27FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail27 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail28FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail28 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail29FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail29 { get; set; }

        [RangeAttribute(1, 8)]
        public virtual int? Brail30FullnessCode { get; set; }

        [RangeAttribute(0, Int32.MaxValue)]
        public virtual int? SamplesFromBrail30 { get; set; }

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

        public virtual LengthSamplingHeader Header { get; set; }
    }
}
