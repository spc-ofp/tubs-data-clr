﻿// -----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL
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
    using System.Text.RegularExpressions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Utilities
    {
        private static Regex multiSpaceRegex = new Regex(@"\s+");
        
        public static string NullSafeToLower(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {   
                return value;
            }

            return value.ToLower();
        }

        public static string NullSafeTrim(this string instring)
        {
            if (String.IsNullOrEmpty(instring))
            {
                return instring;
            }

            return instring.Trim();
        }

        public static string NormalizeSpaces(string instring)
        {
            // Don't bother with null or empty strings
            if (String.IsNullOrEmpty(instring))
            {
                return instring;
            }

            string retval = multiSpaceRegex.IsMatch(instring) ?
                multiSpaceRegex.Replace(instring, " ") : instring;

            return retval;
        }
    }
}