// -----------------------------------------------------------------------
// <copyright file="PollutionDetail.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using Spc.Ofp.Tubs.DAL.Common;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// PollutionDetail represents an entry in either the
    /// "Waste Dumped Overboard" or "Oil Spillages and Leakages" subsections.
    /// </summary>
    public abstract class PollutionDetail
    {
        public virtual int Id { get; set; }

        public virtual PollutionEvent Header { get; set; }

        [EnumDataType(typeof(PollutionType))]
        [Display(ResourceType = typeof(FieldNames), Name = "PollutionType")]
        public virtual PollutionType? PollutionType { get; set; }        

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "Description")]
        public virtual string Description { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Quantity")]
        public virtual string Quantity { get; set; }

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
