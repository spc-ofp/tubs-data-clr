// -----------------------------------------------------------------------
// <copyright file="IAuditable.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
{
    using System;

    /// <summary>
    /// Interface for marking an entity as auditable.
    /// </summary>
    public interface IAuditable
    {
        string EnteredBy { get; set; }

        DateTime? EnteredDate { get; set; }

        string UpdatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        void SetAuditTrail(string userName, DateTime timestamp);
    }
}
