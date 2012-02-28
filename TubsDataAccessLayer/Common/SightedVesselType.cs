// -----------------------------------------------------------------------
// <copyright file="SightedVesselType.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent entries in the table
    /// obsv.ref_sightings_type
    /// </summary>
    public enum SightedVesselType
    {
        /// <summary>
        /// Single Purse Seine
        /// </summary>
        [Description("Single Purse Seine")]
        SinglePurseSeine = 1,

        /// <summary>
        /// Longline
        /// </summary>
        [Description("Longline")]
        Longline = 2,

        /// <summary>
        /// Pole and line
        /// </summary>
        [Description("Pole and line")]
        PoleAndLine = 3,

        /// <summary>
        /// Mothership
        /// </summary>
        [Description("Mothership")]
        Mothership = 4,

        /// <summary>
        /// Troll
        /// </summary>
        [Description("Troll")]
        Troll = 5,

        /// <summary>
        /// Net Boat
        /// </summary>
        [Description("Net Boat")]
        NetBoat = 6,

        /// <summary>
        /// Bunker
        /// </summary>
        [Description("Bunker")]
        Bunker = 7,

        /// <summary>
        /// Search, Anchor or light boat  
        /// </summary>
        [Description("Search, Anchor or light boat")]
        SearchAnchorOrLightBoat = 8,

        /// <summary>
        /// Fish Carrier
        /// </summary>
        [Description("Fish Carrier")]
        FishCarrier = 9,

        /// <summary>
        /// Trawler
        /// </summary>
        [Description("Trawler")]
        Trawler = 10,

        /// <summary>
        /// Light Aircraft
        /// </summary>
        [Description("Light Aircraft")]
        LightAircraft = 21,

        /// <summary>
        /// Helicopter
        /// </summary>
        [Description("Helicopter")]
        Helicopter = 22,

        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        Other = 31,
    }
}
