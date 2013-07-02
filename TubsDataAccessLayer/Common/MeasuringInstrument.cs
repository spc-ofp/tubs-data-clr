// -----------------------------------------------------------------------
// <copyright file="WorkbookVersion.cs" company="Secretariat of the Pacific Community">
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
    /// Instruments used to measure fish length.
    /// </summary>
    public enum MeasuringInstrument
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown,

        /// <summary>
        /// Aluminum Caliper
        /// </summary>
        [Description("Aluminum Caliper")]
        C,

        /// <summary>
        /// Wooden Caliper
        /// </summary>
        [Description("Wooden Caliper")]
        W,

        /// <summary>
        /// Board
        /// </summary>
        [Description("Board")]
        B,

        /// <summary>
        /// Deck Tape
        /// </summary>
        [Description("Deck Tape")]
        T,

        /// <summary>
        /// Ruler
        /// </summary>
        [Description("Ruler")]
        R,
    }
}
