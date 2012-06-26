// -----------------------------------------------------------------------
// <copyright file="FateCode.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent the values in ref_fat
    /// </summary>
    public enum FateCode
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Discarded - Line cut or Other
        /// </summary>
        [Description("Discarded - Line cut or Other")]
        DCF,

        /// <summary>
        /// Discarded - Difficult to land
        /// </summary>
        [Description("Discarded - Difficult to land")]
        DDL,

        /// <summary>
        /// Discarded - fins removed and trunk discarded
        /// </summary>
        [Description("Discarded - fins removed and trunk discarded")]
        DFR,

        /// <summary>
        /// Discarded - Discarded from well
        /// </summary>
        [Description("Discarded - Discarded from well")]
        DFW,

        /// <summary>
        /// Discarded - Gear damage
        /// </summary>
        [Description("Discarded - Gear damage")]
        DGD,

        /// <summary>
        /// Discarded - No space in freezer
        /// </summary>
        [Description("Discarded - No space in freezer")]
        DNS,

        /// <summary>
        /// Discarded - other reason (specify)
        /// </summary>
        [Description("Discarded - other reason (specify)")]
        DOR,

        /// <summary>
        /// Discarded - Protected species - Alive
        /// </summary>
        [Description("Discarded - Protected species - Alive")]
        DPA,

        /// <summary>
        /// Discarded - Protected species - Dead
        /// </summary>
        [Description("Discarded - Protected species - Dead")]
        DPD,

        /// <summary>
        /// Discarded - poor quality
        /// </summary>
        [Description("Discarded - poor quality")]
        DPQ,

        /// <summary>
        /// Discarded - protected species (e.g. turtles)
        /// </summary>
        [Description("Discarded - protected species (e.g. turtles)")]
        DPS,

        /// <summary>
        /// Discarded - Protected Species - Condition unknown
        /// </summary>
        [Description("Discarded - Protected Species - Condition unknown")]
        DPU,

        /// <summary>
        /// Discarded - Shark damage
        /// </summary>
        [Description("Discarded - Shark damage")]
        DSD,

        /// <summary>
        /// Discarded - rejected (struck off before landing)
        /// </summary>
        [Description("Discarded - rejected (struck off before landing)")]
        DSO,

        /// <summary>
        /// Discarded - too small
        /// </summary>
        [Description("Discarded - too small")]
        DTS,

        /// <summary>
        /// Discarded - Undesirable species
        /// </summary>
        [Description("Discarded - Undesirable species")]
        DUS,

        /// <summary>
        /// Discarded - Vessel fully loaded
        /// </summary>
        [Description("Discarded - Vessel fully loaded")]
        DVF,

        /// <summary>
        /// Discarded - Whale damage
        /// </summary>
        [Description("Discarded - Whale damage")]
        DWD,

        /// <summary>
        /// Escaped
        /// </summary>
        [Description("Escaped")]
        ESC,

        /// <summary>
        /// Retained - Crew Consumption
        /// </summary>
        [Description("Retained - Crew Consumption")]
        RCC,

        /// <summary>
        /// Retained - Filletted
        /// </summary>
        [Description("Retained - Filletted")]
        RFL,

        /// <summary>
        /// Retained  - fins removed and trunk retained
        /// </summary>
        [Description("Retained  - fins removed and trunk retained")]
        RFR,

        /// <summary>
        /// Retained  - gilled and gutted (retained for sale)
        /// </summary>
        [Description("Retained  - gilled and gutted (retained for sale)")]
        RGG,

        /// <summary>
        /// Retained - gutted only
        /// </summary>
        [Description("Retained - gutted only")]
        RGO,

        /// <summary>
        /// Retained - gilled gutted and tailed (for sale)
        /// </summary>
        [Description("Retained - gilled gutted and tailed (for sale)")]
        RGT,

        /// <summary>
        /// Retained  - headed and gutted (Marlin)
        /// </summary>
        [Description("Retained  - headed and gutted (Marlin)")]
        RHG,

        /// <summary>
        /// Retained - Headed, gutted and tailed
        /// </summary>
        [Description("Retained - Headed, gutted and tailed")]
        RHT,

        /// <summary>
        /// Retained - fins removed/trunk retained (MANDATORY)
        /// </summary>
        [Description("Retained - fins removed/trunk retained (MANDATORY)")]
        RMD,

        /// <summary>
        /// Retained  - other reason (specify)
        /// </summary>
        [Description("Retained  - other reason (specify)")]
        ROR,

        /// <summary>
        /// Retained  - partial (e.g. fillet, loin)
        /// </summary>
        [Description("Retained  - partial (e.g. fillet, loin)")]
        RPT,

        /// <summary>
        /// Retained  - Shark damage
        /// </summary>
        [Description("Retained  - Shark damage")]
        RSD,

        /// <summary>
        /// Retained - Tailed
        /// </summary>
        [Description("Retained - Tailed")]
        RTL,

        /// <summary>
        /// Retained - Whale Damage
        /// </summary>
        [Description("Retained - Whale Damage")]
        RWD,

        /// <summary>
        /// Retained - Winged
        /// </summary>
        [Description("Retained - Winged")]
        RWG,

        /// <summary>
        /// Retained  - whole
        /// </summary>
        [Description("Retained  - whole")]
        RWW,

        /// <summary>
        /// Unknown - not observed
        /// </summary>
        [Description("Unknown - not observed")]
        UUU,
    }
}
