// -----------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="Secretariat of the Pacific Community">
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
    using System.Reflection;

    /// <summary>
    /// Extension methods for working with enumerations.
    /// </summary>
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            if (null == e)
            {
                return String.Empty;
            }

            FieldInfo fi = e.GetType().GetField(e.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (null != attributes && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return e.ToString();
        }

        public static bool IsVelocity(this UnitOfMeasure unit)
        {
            return unit == UnitOfMeasure.MetersPerSecond || unit == UnitOfMeasure.Knots;
        }
    }
}
