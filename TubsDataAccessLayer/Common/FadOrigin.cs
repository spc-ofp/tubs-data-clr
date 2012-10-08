// -----------------------------------------------------------------------
// <copyright file="FadOrigin.cs" company="Secretariat of the Pacific Community">
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
    public enum FadOrigin
    {
        /// <summary>
        /// No value provided
        /// </summary>
        [Description("No value provided")]
        None = 0,

        /// <summary>
        /// Your vessel deployed this trip
        /// </summary>
        [Description("Your vessel deployed this trip")]
        DeployedThisTrip = 250,

        /// <summary>
        /// Your vessel deployed previous trip
        /// </summary>
        [Description("Your vessel deployed previous trip")]
        DeployedPreviousTrip = 251,

        /// <summary>
        /// Other vessel (owner consent)
        /// </summary>
        [Description("Other vessel (owner consent)")]
        OtherVesselOwnerConsent = 252,

        /// <summary>
        /// Other vessel (no owner consent)
        /// </summary>
        [Description("Other vessel (no owner consent)")]
        OtherVesselNoOwnerConsent = 253,

        /// <summary>
        /// Other vessel (consent unknown)
        /// </summary>
        [Description("Other vessel (consent unknown)")]
        OtherVesselConsentUnknown = 254,

        /// <summary>
        /// Drifting and found by your vessel
        /// </summary>
        [Description("Drifting and found by your vessel")]
        FoundDrifting = 255,

        /// <summary>
        /// Deployed by FAD auxillary vessel
        /// </summary>
        [Description("Deployed by FAD auxillary vessel")]
        DeployedByAuxillary = 256,

        /// <summary>
        /// Origin unknown
        /// </summary>
        [Description("Origin unknown")]
        Unknown = 257,

        /// <summary>
        /// Other origin
        /// </summary>
        [Description("Other origin")]
        Other = 258, 
    }
}
