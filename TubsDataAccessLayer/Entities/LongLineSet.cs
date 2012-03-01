// -----------------------------------------------------------------------
// <copyright file="LongLineSet.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Tubs.DAL.Entities
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
    /// Long line set details as recorded on form LL-3
    /// </summary>
    public class LongLineSet
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual int? SetNumber { get; set; }

        public virtual bool? WasObserved { get; set; }

        public virtual DateTime? SetDateOnly { get; set; }

        public virtual string SetTimeOnly { get; set; }

        public virtual DateTime SetDate { get; set; }

        public virtual int? SetId { get; set; }

        public virtual DateTime? UtcSetDateOnly { get; set; }

        public virtual string UtcSetTimeOnly { get; set; }

        public virtual DateTime? UtcSetDate { get; set; }

        public virtual int? HooksBetweenFloats { get; set; }

        public virtual int? BasketsSet { get; set; } // ???

        public virtual int? BasketsObserved { get; set; }

        public virtual int? HooksSet { get; set; }

        public virtual int? EstimatedHooks { get; set; }

        public virtual int? ObservedHooks { get; set; }

        public virtual string CalculatedHooks { get; set; }

        public virtual int? FloatLength { get; set; }

        public virtual decimal? LineSpeed { get; set; }

        public virtual string LineSpeedUnit { get; set; }

        public virtual decimal? LineSpeedMetersPerSecond { get; set; }

        public virtual int? BranchInterval { get; set; }

        public virtual decimal? BranchDistance { get; set; }

        public virtual decimal? BranchLength { get; set; }

        public virtual decimal? VesselSpeed { get; set; }


    }
}
