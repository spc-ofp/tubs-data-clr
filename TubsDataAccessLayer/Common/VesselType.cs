// -----------------------------------------------------------------------
// <copyright file="VesselType.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent the reference_id values for source 'VATYP'
    /// </summary>
    public enum VesselType
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Single Purse Seine
        /// </summary>
        [Description("Single Purse Seine")]
        SinglePurseSeine = 47,

        /// <summary>
        /// Longline
        /// </summary>
        [Description("Longline")]
        Longline = 48,

        /// <summary>
        /// Pole and line
        /// </summary>
        [Description("Pole and line")]
        PoleAndLine = 49,

        /// <summary>
        /// Mothership
        /// </summary>
        [Description("Mothership")]
        Mothership = 50,

        /// <summary>
        /// Troll
        /// </summary>
        [Description("Troll")]
        Troll = 51,

        /// <summary>
        /// Net Boat
        /// </summary>
        [Description("Net Boat")]
        NetBoat = 52,

        /// <summary>
        /// Bunker
        /// </summary>
        [Description("Bunker")]
        Bunker = 53,

        /// <summary>
        /// Search, Anchor or light boat
        /// </summary>
        [Description("Search, Anchor or light boat")]
        SearchAnchorOrLightBoat = 54,

        /// <summary>
        /// Fish Carrier
        /// </summary>
        [Description("Fish Carrier")]
        FishCarrier = 55,

        /// <summary>
        /// Trawler
        /// </summary>
        [Description("Trawler")]
        Trawler = 56,

        /// <summary>
        /// Light Aircraft
        /// </summary>
        [Description("Light Aircraft")]
        LightAircraft = 57,

        /// <summary>
        /// Helicopter
        /// </summary>
        [Description("Helicopter")]
        Helicopter = 58,

        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        Other = 59
    }
}
