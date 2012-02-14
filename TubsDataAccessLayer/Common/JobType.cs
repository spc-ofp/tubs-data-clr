// -----------------------------------------------------------------------
// <copyright file="JobType.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent the reference_id values for source 'VSJOB'
    /// </summary>
    public enum JobType
    {
        /// <summary>
        /// No value provided or unknown
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Captain
        /// </summary>
        [Description("Captain")]
        Captain = 37,

        /// <summary>
        /// Navigator/Master
        /// </summary>
        [Description("Navigator/Master")]
        NavigatorOrMaster = 38,

        /// <summary>
        /// Mate
        /// </summary>
        [Description("Mate")]
        Mate = 39,

        /// <summary>
        /// Chief Engineer
        /// </summary>
        [Description("Chief Engineer")]
        ChiefEngineer = 40,

        /// <summary>
        /// Assistant Engineer
        /// </summary>
        [Description("Assistant Engineer")]
        AssistantEngineer = 41,

        /// <summary>
        /// Deck Boss
        /// </summary>
        [Description("Deck Boss")]
        DeckBoss = 42,

        /// <summary>
        /// Cook
        /// </summary>
        [Description("Cook")]
        Cook = 43,

        /// <summary>
        /// Helicopter Pilot
        /// </summary>
        [Description("Helicopter Pilot")]
        HelicopterPilot = 44,

        /// <summary>
        /// Skiff Man
        /// </summary>
        [Description("Skiff Man")]
        SkiffMan = 45,

        /// <summary>
        /// Winch Man
        /// </summary>
        [Description("Winch Man")]
        WinchMan = 46,

        /// <summary>
        /// Helicopter Mechanic
        /// </summary>
        [Description("Helicopter Mechanic")]
        HelicopterMechanic = 105,

        /// <summary>
        /// Generic crew member
        /// </summary>
        [Description("Crew")]
        Crew = 107
    }
}
