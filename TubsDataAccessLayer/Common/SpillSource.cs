// -----------------------------------------------------------------------
// <copyright file="SpillSource.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent the reference_id values for source 'POLSR'
    /// </summary>
    public enum SpillSource
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Waste dumped overboard
        /// </summary>
        [Description("Vessel Aground/Collision")]
        VesselAgroundOrCollision = 66,

        /// <summary>
        /// Vessel at Anchor/Berth
        /// </summary>
        [Description("Vessel at Anchor/Berth")]
        VesselAtAnchorOrBerth = 67,

        /// <summary>
        /// Vessel Underway
        /// </summary>
        [Description("Vessel Underway")]
        VesselUnderway = 68,

        /// <summary>
        /// Land Based Source
        /// </summary>
        [Description("Land Based Source")]
        LandBasedSource = 69,

        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        Other = 70,
    }
}
