// -----------------------------------------------------------------------
// <copyright file="UsageCode.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent codes from [obsv].[ref_usage]
    /// </summary>
    public enum UsageCode
    {
        /// <summary>
        /// Used all the time in fishing
        /// </summary>
        [Description("Used all the time in fishing")]
        ALL,

        /// <summary>
        /// Used only in transit
        /// </summary>
        [Description("Used only in transit")]
        TRA,

        /// <summary>
        /// Used often in fishing
        /// </summary>
        [Description("Used often in fishing")]
        OIF,

        /// <summary>
        /// Used sometimes in fishing
        /// </summary>
        [Description("Used sometimes in fishing")]
        SIF,

        /// <summary>
        /// Rarely used
        /// </summary>
        [Description("Rarely used")]
        RAR,

        /// <summary>
        /// Broken now but used normally
        /// </summary>
        [Description("Broken now but used normally")]
        BRO,

        /// <summary>
        /// No longer ever used
        /// </summary>
        [Description("No longer ever used")]
        NOL,

        /// <summary>
        /// Not applicable / Not filled
        /// </summary>
        [Description("Not applicable / Not filled")]
        NA
    }
}
