// -----------------------------------------------------------------------
// <copyright file="PollutionDetail.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// PollutionDetail represents an entry in either the
    /// "Waste Dumped Overboard" or "Oil Spillages and Leakages" subsections.
    /// </summary>
    public class PollutionDetail
    {
        public virtual int Id { get; set; }

        public virtual PollutionEvent Header { get; set; }

        public virtual PollutionType? PollutionType { get; set; }

        public virtual PollutionMaterial? Material { get; set; }

        public virtual string Description { get; set; }

        public virtual string Quantity { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }
    }
}
