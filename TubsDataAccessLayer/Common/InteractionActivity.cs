// -----------------------------------------------------------------------
// <copyright file="InteractionActivity.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent the reference_id values for source
    /// 'SGACT'.
    /// </summary>
    public enum InteractionActivity
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Setting
        /// </summary>
        [Description("Setting")]
        Setting = 73,

        /// <summary>
        /// Hauling
        /// </summary>
        [Description("Hauling")]
        Hauling = 74,

        /// <summary>
        /// Searching
        /// </summary>
        [Description("Searching")]
        Searching = 75,

        /// <summary>
        /// Transit
        /// </summary>
        [Description("Transit")]
        Transit = 76,


        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        Other = 77,
    }
}
