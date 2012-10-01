// -----------------------------------------------------------------------
// <copyright file="DateExtensions.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// Extension methods for working with DateTime values.
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Merge combines an existing DateTime object with a string
        /// time of day.
        /// </summary>
        /// <param name="dateOnly"></param>
        /// <param name="timeOnly"></param>
        /// <returns></returns>
        public static DateTime? Merge(this DateTime? dateOnly, string timeOnly)
        {
            timeOnly = timeOnly.NullSafeTrim();
            if (!dateOnly.HasValue || null == timeOnly || timeOnly.Length != 4)
            {
                return dateOnly;
            }

            DateTime mergedDate = new DateTime(dateOnly.Value.Ticks);
            var hourString = timeOnly.Substring(0, 2);
            var minuteString = timeOnly.Substring(2, 2);
            int hours = 0;
            int minutes = 0;
            if (Int32.TryParse(hourString, out hours) && Int32.TryParse(minuteString, out minutes))
            {
                mergedDate = mergedDate.Add(new TimeSpan(hours, minutes, 0));
            }
            return mergedDate;
        }
		
		public static DateTime Merge(this DateTime dateOnly, string timeOnly)
        {
            timeOnly = timeOnly.NullSafeTrim();
            if (null == timeOnly || timeOnly.Length != 4)
            {
                return dateOnly;
            }

            DateTime mergedDate = new DateTime(dateOnly.Ticks);
            var hourString = timeOnly.Substring(0, 2);
            var minuteString = timeOnly.Substring(2, 2);
            int hours = 0;
            int minutes = 0;
            if (Int32.TryParse(hourString, out hours) && Int32.TryParse(minuteString, out minutes))
            {
                mergedDate = mergedDate.Add(new TimeSpan(hours, minutes, 0));
            }
            return mergedDate;
        }

        public static DateTime? Parse(this string dateValue, string formatString = "dd/MM/yy")
        {
            dateValue = dateValue.NullSafeTrim();
            if (String.IsNullOrEmpty(dateValue) || String.IsNullOrEmpty(formatString))
                return null;

            DateTime parsed;
            var result = DateTime.TryParseExact(
                dateValue,
                formatString,
                null,
                System.Globalization.DateTimeStyles.None,
                out parsed);

            if (result)
                return parsed;

            return null;
        }
    }
}
