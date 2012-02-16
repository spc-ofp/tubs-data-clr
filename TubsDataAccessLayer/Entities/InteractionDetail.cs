// -----------------------------------------------------------------------
// <copyright file="InteractionDetail.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class InteractionDetail
    {
        public virtual int Id { get; protected set; }
        
        public virtual SpecialSpeciesInteraction Header { get; set; }

        public virtual string StartOrEnd { get; set; }

        public virtual int? Number { get; set; }

        public virtual ConditionCode? ConditionCode { get; set; }

        public virtual string Description { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }
    }
}
