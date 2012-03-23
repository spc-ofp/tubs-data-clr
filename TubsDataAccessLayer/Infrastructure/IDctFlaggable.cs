// -----------------------------------------------------------------------
// <copyright file="IDctFlaggable.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
{
    using System;

    /// <summary>
    /// Interface for marking records that can be flagged with DCT notes 
    /// and/or a confidence score.
    /// </summary>
    public interface IDctFlaggable
    {
        string DctNotes { get; set; }

        int? DctScore { get; set; }
    }
}
