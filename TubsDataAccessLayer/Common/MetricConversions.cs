// -----------------------------------------------------------------------
// <copyright file="MetricConversions.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;

    /// <summary>
    /// Since the JSR-275 work didn't work out, here's a quick and dirty hack to
    /// manage unit conversions.
    /// </summary>
    public static class MetricConversions
    {
        // You can always tell a Perl programmer, but you can't tell him much...
        private static IDictionary<UnitOfMeasure, decimal> ToMeters = new Dictionary<UnitOfMeasure, decimal>()
        {
            { UnitOfMeasure.Kilometers, 1000.0m },    
            { UnitOfMeasure.Meters, 1.0m },            
            { UnitOfMeasure.Centimeters, .01m },
            { UnitOfMeasure.Inches, 0.0254m },
            { UnitOfMeasure.Fathoms, 1.8288m },
            { UnitOfMeasure.NauticalMiles, 1852.0m },
            { UnitOfMeasure.Yards, 0.9144m }
        };

        private static IDictionary<UnitOfMeasure, decimal> FromMeters = new Dictionary<UnitOfMeasure, decimal>()
        {
            { UnitOfMeasure.Kilometers, .001m },    
            { UnitOfMeasure.Meters, 1.0m },            
            { UnitOfMeasure.Centimeters, 100.0m },
            { UnitOfMeasure.Inches, 39.37m },
            { UnitOfMeasure.Fathoms, 0.5468m },
            { UnitOfMeasure.NauticalMiles, 0.00054m },
            { UnitOfMeasure.Yards, 1.0936m }
        };

        private static decimal KnotsToMps = 0.51444m;
        private static decimal MpsToKnots = 1.944m;

        public static decimal KnotsToMetersPerSecond(decimal knots)
        {
            return knots * KnotsToMps;
        }

        public static decimal MetersPerSecondToKnots(decimal mps)
        {
            return mps * MpsToKnots;
        }

        public static decimal ConvertLengthToMeters(decimal quantity, UnitOfMeasure sourceUnit)
        {
            if (!ToMeters.ContainsKey(sourceUnit))
            {
                throw new ArgumentException("Invalid conversion type", "sourceUnit");
            }
            return ToMeters[sourceUnit] * quantity;
        }

        public static decimal ConvertLengthFromMeters(decimal quantity, UnitOfMeasure targetUnit)
        {
            if (!FromMeters.ContainsKey(targetUnit))
            {
                throw new ArgumentException("Invalid conversion type", "targetUnit");
            }
            return FromMeters[targetUnit] * quantity;
        }
    }
}
