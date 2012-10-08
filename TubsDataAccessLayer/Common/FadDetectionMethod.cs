// -----------------------------------------------------------------------
// <copyright file="FadDetectionMethod.cs" company="Secretariat of the Pacific Community">
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
    /// Enumeration of codes for how a FAD was detected
    /// </summary>
    public enum FadDetectionMethod
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Seen from Vessel
        /// </summary>
        [Description("Seen from Vessel")]
        SeenFromVessel = 200,

        /// <summary>
        /// Seen from Helicopter
        /// </summary>
        [Description("Seen from Helicopter")]
        SeenFromHelicopter = 201,

        /// <summary>
        /// Marked with Radio beacon
        /// </summary>
        [Description("Marked with Radio beacon")]
        MarkedWithRadioBeacon = 202,

        /// <summary>
        /// Bird Radar
        /// </summary>
        [Description("Bird Radar")]
        BirdRadar = 203,

        /// <summary>
        /// Info. from other vessel
        /// </summary>
        [Description("Info. from other vessel")]
        InfoFromOtherVessel = 204,

        /// <summary>
        /// Anchored (GPS)
        /// </summary>
        [Description("Anchored (GPS)")]
        AnchoredGps = 205,

        /// <summary>
        /// Marked with Satellite Beacon
        /// </summary>
        [Description("Marked with Satellite Beacon")]
        MarkedWithSatelliteBeacon = 206,

        /// <summary>
        /// Navigation Radar
        /// </summary>
        [Description("Navigation Radar")]
        NavigationRadar = 207,

        /// <summary>
        /// Lights
        /// </summary>
        [Description("Lights")]
        Lights = 208,

        /// <summary>
        /// Flock of Birds sighted from vessel
        /// </summary>
        [Description("Flock of Birds sighted from vessel")]
        FlockOfBirds = 209,

        /// <summary>
        /// Other (please specify)
        /// </summary>
        [Description("Other (please specify)")]
        Other = 210,

        /// <summary>
        /// "Vessel deploying FAD (not detected)
        /// </summary>
        [Description("Vessel deploying FAD (not detected)")]
        VesselDeployingFad = 211
        
    }
}
