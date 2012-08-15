// -----------------------------------------------------------------------
// <copyright file="GonadStage.cs" company="Secretariat of the Pacific Community">
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
    public enum GonadStage
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// No Information
        /// </summary>
        [Description("No Information")]
        NoInformation = 1,

        /// <summary>
        /// Ovary small and slender. Cross-section round
        /// </summary>
        [Description("Ovary small and slender. Cross-section round.")]
        Immature = 2,

        /// <summary>
        /// Enlarged, pale yellow ovaries. Ova not visible.
        /// </summary>
        [Description("Enlarged, pale yellow ovaries. Ova not visible.")]
        EarlyMaturing = 3,

        /// <summary>
        /// Enlarged, turgid, orange-yellow ovaries. Ova opaque
        /// </summary>
        [Description("Enlarged, turgid, orange-yellow ovaries. Ova opaque")]
        LateMaturing = 4,

        /// <summary>
        /// Enlarged, richly vascular, orange ovaries, losing turgidity. Ova translucent.
        /// </summary>
        [Description("Enlarged, richly vascular, orange ovaries, losing turgidity. Ova translucent.")]
        Mature = 5,

        /// <summary>
        /// Greatly enlargened ovaires, not turgid. Ova easily dislogded and extruded by pressure.
        /// </summary>
        [Description("Greatly enlargened ovaires, not turgid. Ova easily dislogded and extruded by pressure.")]
        Ripe = 6,

        /// <summary>
        /// Flaccid, vascular ovaries. Most ova gone. Often dark orange-red coloration.
        /// </summary>
        [Description("Flaccid, vascular ovaries. Most ova gone. Often dark orange-red coloration.")]
        Spent = 7,

        /// <summary>
        /// Vascular ovaries. Next batch of ova developing.
        /// </summary>
        [Description("Vascular ovaries. Next batch of ova developing.")]
        Recovering = 8,

        /// <summary>
        /// Female (Not sure why this is a gonad stage)
        /// </summary>
        [Description("Female")]
        F = 9,

        /// <summary>
        /// Male (Not sure why this is a gonad stage)
        /// </summary>
        [Description("Male")]
        M = 10,

        /// <summary>
        /// Neuter (Not sure why this is a gonad stage)
        /// </summary>
        [Description("Neuter")]
        N = 11,

        /// <summary>
        /// Unknown (Not sure why this is a gonad stage)
        /// </summary>
        [Description("Unknown")]
        U = 12,

        /// <summary>
        /// X (Not sure why this is a gonad stage)
        /// </summary>
        [Description("X")]
        X = 13,

        /// <summary>
        /// Y (Not sure why this is a gonad stage)
        /// </summary>
        [Description("Y")]
        Y = 14
    }
}
