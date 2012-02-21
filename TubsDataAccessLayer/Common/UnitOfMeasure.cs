// -----------------------------------------------------------------------
// <copyright file="UnitOfMeasure.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent units of measurement scattered in [obsv].[ref_ids]
    /// </summary>
    public enum UnitOfMeasure
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Meters
        /// </summary>
        [Description("Meters")]
        Meters = 93,

        /// <summary>
        /// Yards
        /// </summary>
        [Description("Yards")]
        Yards = 94,

        /// <summary>
        /// Fathoms
        /// </summary>
        [Description("Fathoms")]
        Fathoms = 95,

        /// <summary>
        /// Centimeters
        /// </summary>
        [Description("Centimeters")]
        Centimeters = 96,

        /// <summary>
        /// Inches
        /// </summary>
        [Description("Inches")]
        Inches = 97,

        /// <summary>
        /// Meters per second
        /// </summary>
        [Description("Meters per second")]
        MetersPerSecond = 98,

        /// <summary>
        /// Knots
        /// </summary>
        [Description("Knots")]
        Knots = 99,

        /// <summary>
        /// Kilometers
        /// </summary>
        [Description("Kilometers")]
        Kilometers = 103,

        /// <summary>
        /// Nautical miles
        /// </summary>
        [Description("Nautical miles")]
        NauticalMiles = 104,       
    }
}
