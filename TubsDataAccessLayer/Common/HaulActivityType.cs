// -----------------------------------------------------------------------
// <copyright file="HaulActivityType.cs" company="Secretariat of the Pacific Community">
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
    /// 'STEND'.
    /// </summary>
    public enum HaulActivityType
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Start of set
        /// </summary>
        [Description("Start of set")]
        StartOfSet = 83,

        /// <summary>
        /// End of set
        /// </summary>
        [Description("End of set")]
        EndOfSet = 84,

        /// <summary>
        /// Start of haul
        /// </summary>
        [Description("Start of haul")]
        StartOfHaul = 85,

        /// <summary>
        /// End of haul
        /// </summary>
        [Description("End of haul")]
        EndOfHaul = 86,
    }
}
