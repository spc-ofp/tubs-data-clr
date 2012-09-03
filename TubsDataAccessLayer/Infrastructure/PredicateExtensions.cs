// -----------------------------------------------------------------------
// <copyright file="PredicateExtensions.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
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
    using System.Linq.Expressions;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Extension method for turning search criteria into a LINQ expression.
    /// </summary>
    public static class PredicateExtensions
    {
        public static Expression<Func<Trip, bool>> AsPredicate(this SearchCriteria criteria)
        {
            // This could go either way, but for now we'll say no criteria means no trips.
            if (null == criteria)
            {
                return PredicateBuilder.False<Trip>();
            }

            // The problem with really clever code is that, in general, you have to be twice
            // as smart to debug code as you do to write it.  So if you write code at your maximum
            // cleverness, you'll be lost when it comes to debugging it.
            // I could turn this into one big lambda, but then I wouldn't be clever enough to
            // debug it...
            var predicate = PredicateBuilder.True<Trip>(); // If I was using .Or(), I'd replace this with .False()
            if (!String.IsNullOrEmpty(criteria.Observer))
            {
                predicate = predicate.And(trip =>
                    trip.Observer.StaffCode.ToUpper().Contains(criteria.Observer.ToUpper()) ||
                    trip.Observer.FirstName.Contains(criteria.Observer.ToUpper()) ||
                    trip.Observer.LastName.Contains(criteria.Observer.ToUpper())
                );
            }

            if (!String.IsNullOrEmpty(criteria.ProgramCode))
            {
                predicate = predicate.And(trip => trip.ProgramCode.ToString() == criteria.ProgramCode.ToUpper());
            }

            if (!String.IsNullOrEmpty(criteria.Vessel))
            {
                predicate = predicate.And(trip => trip.Vessel.Name.ToUpper().Contains(criteria.Vessel.ToUpper()));
            }

            if (!String.IsNullOrEmpty(criteria.DeparturePort))
            {
                predicate = predicate.And(trip =>
                    trip.DeparturePort.Name.ToUpper().Contains(criteria.DeparturePort.ToUpper()) ||
                    trip.DeparturePort.PortCode.ToUpper().Contains(criteria.DeparturePort.ToUpper())
                );
            }

            if (!String.IsNullOrEmpty(criteria.ReturnPort))
            {
                predicate = predicate.And(trip =>
                    trip.DeparturePort.Name.ToUpper().Contains(criteria.ReturnPort.ToUpper()) ||
                    trip.DeparturePort.PortCode.ToUpper().Contains(criteria.ReturnPort.ToUpper())
                );
            }

            if (criteria.DepartureDate.HasValue)
            {
                predicate = predicate.And(trip => trip.DepartureDate >= criteria.DepartureDate.Value);
            }

            if (criteria.ReturnDate.HasValue)
            {
                predicate = predicate.And(trip => trip.ReturnDate <= criteria.ReturnDate.Value);
            }

            if (!String.IsNullOrEmpty(criteria.AnyPort))
            {
                predicate = predicate.And(trip =>
                    trip.DeparturePort.Name.ToUpper().Contains(criteria.ReturnPort.ToUpper()) ||
                    trip.DeparturePort.PortCode.ToUpper().Contains(criteria.ReturnPort.ToUpper()) ||
                    trip.DeparturePort.Name.ToUpper().Contains(criteria.ReturnPort.ToUpper()) ||
                    trip.DeparturePort.PortCode.ToUpper().Contains(criteria.ReturnPort.ToUpper())
                );
            }

            if (criteria.AnyDate.HasValue)
            {
                predicate = predicate.And(trip =>
                    trip.DepartureDate <= criteria.AnyDate.Value &&
                    trip.ReturnDate >= criteria.AnyDate.Value
                );
            }
            return predicate;
        }
    }
}
