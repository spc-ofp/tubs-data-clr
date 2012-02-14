// -----------------------------------------------------------------------
// <copyright file="ActionType.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent codes from [obsv].[ref_action]
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Aground
        /// </summary>
        [Description("Aground")]
        AG,

        /// <summary>
        /// Bunkering (transfer of fuel), vessel observer is on is giving
        /// </summary>
        [Description("Bunkering (transfer of fuel), vessel observer is on is giving")]
        BG,

        /// <summary>
        /// Bunkering (transfer of fuel), vessel observer is on is receiving
        /// </summary>
        [Description("Bunkering (transfer of fuel), vessel observer is on is receiving")]
        BR,

        /// <summary>
        /// Dumping of fish
        /// </summary>
        [Description("Dumping of fish")]
        DF,

        /// <summary>
        /// Fishing
        /// </summary>
        [Description("Fishing")]
        FI,

        /// <summary>
        /// From set
        /// </summary>
        [Description("From set")]
        FS,

        /// <summary>
        /// Not fishing
        /// </summary>
        [Description("Not fishing")]
        NF,

        /// <summary>
        /// Other, vessel observer is on is giving
        /// </summary>
        [Description("Other, vessel observer is on is giving")]
        OG,

        /// <summary>
        /// Other, vessel observer is on is receiving
        /// </summary>
        [Description("Other, vessel observer is on is receiving")]
        OR,

        /// <summary>
        /// Possibly fishing
        /// </summary>
        [Description("Possibly fishing")]
        PF,

        /// <summary>
        /// Set sharing, vessel observer is on is giving
        /// </summary>
        [Description("Set sharing, vessel observer is on is giving")]
        SG,

        /// <summary>
        /// Set sharing, vessel observer is on is receiving
        /// </summary>
        [Description("Set sharing, vessel observer is on is receiving")]
        SR,

        /// <summary>
        /// Transfering fish between vessels, vessel observer is on is giving
        /// </summary>
        [Description("Transfering fish between vessels, vessel observer is on is giving")]
        TG,

        /// <summary>
        /// Transfering fish between vessels, vessel observer is on is receiving
        /// </summary>
        [Description("Transfering fish between vessels, vessel observer is on is receiving")]
        TR,

        /// <summary>
        /// Unloaded at cannery or cool store
        /// </summary>
        [Description("Unloaded at cannery or cool store")]
        UL,

        /// <summary>
        /// Transferred between wells
        /// </summary>
        [Description("Transferred between wells")]
        WT
    }
}
