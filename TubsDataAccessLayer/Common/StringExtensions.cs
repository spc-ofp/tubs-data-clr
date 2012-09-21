// -----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Secretariat of the Pacific Community">
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
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension methods for working with System.String
    /// </summary>
    public static class StringExtensions
    {
        private const int NumberOfDecimalPlaces = 3;
        private const int HemisphereLength = 1;
        private static Regex multiSpaceRegex = new Regex(@"\s+");

        public static string NullSafeToLower(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : value.ToLower();
        }

        public static string NullSafeToUpper(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : value.ToUpper();
        }

        public static string NullSafeTrim(this string instring)
        {
            return string.IsNullOrEmpty(instring) ? instring : instring.Trim();
        }

        public static string NormalizeSpaces(string instring)
        {
            // Don't bother with null or empty strings
            if (String.IsNullOrEmpty(instring))
            {
                return instring;
            }

            return multiSpaceRegex.IsMatch(instring) ?
                multiSpaceRegex.Replace(instring, " ") : instring;
        }

        private static string AddDecimalSeparator(string value, int fromLeft)
        {
            if (null == value)
            {
                return null;
            }
            if (value.Contains(".") && value.Length == fromLeft + NumberOfDecimalPlaces + HemisphereLength)
            {
                return String.Format("{0}.{1}", value.Substring(0, fromLeft), value.Substring(fromLeft + 1));
            }
            return value;
        }

        public static string ReformatLatitude(this string value)
        {
            return AddDecimalSeparator(value, 4);
        }

        public static string ReformatLongitude(this string value)
        {
            return AddDecimalSeparator(value, 5);
        }
    }
}
