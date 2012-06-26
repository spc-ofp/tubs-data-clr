// -----------------------------------------------------------------------
// <copyright file="LongLineCatch.cs" company="Secretariat of the Pacific Community">
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
    public class LongLineCatch
    {
        public virtual int Id { get; set; }

        public virtual LongLineSet FishingSet { get; set; }

        public virtual DateTime? DateOnly { get; set; }

        public virtual string TimeOnly { get; set; }

        public virtual DateTime? Date { get; set; }

        public virtual int? SampleNumber { get; set; }

        public virtual int? HookNumber { get; set; }

        public virtual string SpeciesCode { get; set; }

        public virtual ConditionCode? LandedConditionCode { get; set; }

        public virtual ConditionCode? DiscardedConditionCode { get; set; }

        public virtual FateCode? FateCode { get; set; }

        public virtual int? Length { get; set; }

        public virtual LengthCode? LengthCode { get; set; }

        public virtual decimal? Weight { get; set; }

        public virtual decimal? EstimatedWeight { get; set; }

        public virtual decimal? EstimatedWeightReliability { get; set; }

        public virtual string WeightCode { get; set; } // TODO Replace with enum

        public virtual SexCode? SexCode { get; set; }

        public virtual string Spare1 { get; set; } // WTF???

        public virtual int? GonadStage { get; set; } // TODO Replace with enum

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
