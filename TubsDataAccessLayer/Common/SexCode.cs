// -----------------------------------------------------------------------
// <copyright file="SexCode.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent codes from [obsv].[ref_sex]
    /// </summary>
    public enum SexCode
    {
        /// <summary>
        /// Female
        /// </summary>
        [Description("Female")]
        F,

        /// <summary>
        /// Indeterminate (checked but unsure)
        /// </summary>
        [Description("Indeterminate")]
        I,

        /// <summary>
        /// Male
        /// </summary>
        [Description("Male")]
        M,

        /// <summary>
        /// Unknown (not checked)
        /// </summary>
        [Description("Unknown")]
        U,
    }
}
