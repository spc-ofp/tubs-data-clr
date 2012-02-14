// -----------------------------------------------------------------------
// <copyright file="DetectionMethod.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent the reference_id values for source 'DETON'
    /// </summary>
    public enum DetectionMethod
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Seen from vessel
        /// </summary>
        [Description("Seen from vessel")]
        SeenFromVessel = 30,

        /// <summary>
        /// Seen from helicopter
        /// </summary>
        [Description("Seen from helicopter")]
        SeenFromHelicopter = 31,

        /// <summary>
        /// Marked with beacon
        /// </summary>
        [Description("Marked with beacon")]
        MarkedWithBeacon = 32,

        /// <summary>
        /// Bird radar
        /// </summary>
        [Description("Bird radar")]
        BirdRadar = 33,

        /// <summary>
        /// Sonar/depth sounder
        /// </summary>
        [Description("Sonar/depth sounder")]
        Sonar = 34,

        /// <summary>
        /// Info. from other vessel
        /// </summary>
        [Description("Info. from other vessel")]
        InfoFromOtherVessel = 35,

        /// <summary>
        /// Anchored FAD/payao (recorded)
        /// </summary>
        [Description("Anchored FAD/payao (recorded)")]
        Anchored = 36,
    }
}
