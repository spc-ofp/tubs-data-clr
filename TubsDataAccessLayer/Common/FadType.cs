// -----------------------------------------------------------------------
// <copyright file="FadType.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Common
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
    using System.ComponentModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public enum FadType
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Man made object (Drifting FAD)
        /// </summary>
        [Description("Man made object (Drifting FAD)")]
        ManMadeFad = 215,

        /// <summary>
        /// Man made object (Non FAD)
        /// </summary>
        [Description("Man made object (Non FAD)")]
        ManMadeNonFad = 216,

        /// <summary>
        /// Tree or log (natural, free floating)
        /// </summary>
        [Description("Tree or log (natural, free floating)")]
        NaturalTreeOrLog = 217,

        /// <summary>
        /// Tree or logs (converted into FAD)
        /// </summary>
        [Description("Tree or logs (converted into FAD)")]
        ConvertedTreeOrLog = 218,

        /// <summary>
        /// Debris (flotsam bunched together)
        /// </summary>
        [Description("Debris (flotsam bunched together)")]
        Debris = 219,

        /// <summary>
        /// Dead Animal (specify; i.e. whale, horse, etc.)
        /// </summary>
        [Description("Dead Animal (specify; i.e. whale, horse, etc.)")]
        DeadAnimal = 220,

        /// <summary>
        /// Anchored Raft, FAD, or Payao
        /// </summary>
        [Description("Anchored Raft, FAD, or Payao")]
        AnchoredRaftFadOrPayao = 221,

        /// <summary>
        /// Anchored Tree or Logs
        /// </summary>
        [Description("Anchored Tree or Logs")]
        AnchoredTreeOrLogs = 222,

        /// <summary>
        /// Other (please specify)
        /// </summary>
        [Description("Other (please specify)")]
        Other = 223,

        /// <summary>
        /// Man made object (Drifting FAD)-changed
        /// </summary>
        [Description("Man made object (Drifting FAD)-changed")]
        ManMadeFadChanged = 224, 
    }
}
