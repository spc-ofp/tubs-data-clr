// -----------------------------------------------------------------------
// <copyright file="SchoolAssociation.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent the reference_id values for source 'SCHAS'
    /// </summary>
    public enum SchoolAssociation
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Unassociated
        /// </summary>
        [Description("Unassociated")]
        Unassociated = 21,

        /// <summary>
        /// Feeding on baitfish
        /// </summary>
        [Description("Feeding on baitfish")]
        FeedingOnBaitfish = 22,

        /// <summary>
        /// Drifting log, debris, or dead animal
        /// </summary>
        [Description("Drifting log, debris, or dead animal")]
        DriftingLog = 23,

        /// <summary>
        /// Drifting raft, FAD or payao
        /// </summary>
        [Description("Drifting raft, FAD or payao")]
        DriftingRaft = 24,

        /// <summary>
        /// Anchored raft, FAD or payao
        /// </summary>
        [Description("Anchored raft, FAD or payao")]
        AnchoredRaft = 25,

        /// <summary>
        /// Live whale
        /// </summary>
        [Description("Live whale")]
        LiveWhale = 26,

        /// <summary>
        /// Live whale shark
        /// </summary>
        [Description("Live whale shark")]
        LiveWhaleShark = 27,

        /// <summary>
        /// Other (please specify)
        /// </summary>
        [Description("Other (please specify)")]
        Other = 28,

        /// <summary>
        /// No tuna associated
        /// </summary>
        [Description("No tuna associated")]
        NoTuna = 29,

        /// <summary>
        /// Whale, Whale Shark, or Porpoise (old forms)
        /// </summary>
        [Description("Whale, Whale Shark, or Porpoise (old forms)")]
        WhaleWhaleSharkPorpoise = 119
    }
}
