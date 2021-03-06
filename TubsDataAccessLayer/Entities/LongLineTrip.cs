﻿// <copyright file="LongLineTrip.cs" company="Secretariat of the Pacific Community">
//  Copyright (c) 2011 Secretariat of the Pacific Community
// </copyright>
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
    using System.Linq;

    /// <summary>
    /// Long line trip entity.
    /// </summary>
    public class LongLineTrip : Trip
    {
        public LongLineTrip()
            : base()
        {
            this.FishingSets = new List<LongLineSet>(24); // TODO Determine the correct number
        }

        public override Gear GetGear()
        {
            return this.Gear;
        }

        public virtual LongLineGear Gear { get; set; }

        public virtual IList<LongLineSet> FishingSets { get; protected internal set; }

        // TODO:  Add total catch
        // TODO:  Add CPUE (depends on total catch)

        /// <summary>
        /// Standard unit of effort in long line fishing is 100 hooks.
        /// </summary>
        /// <remarks>
        /// Preference is hook_set, then hook_observed, then hook_est
        /// TODO:  Confirm correct order.
        /// </remarks>
        public virtual decimal UnitEffort
        {
            get
            {
                return (
                    from fset in this.FishingSets
                    select fset.TotalHookCount.HasValue ? (decimal)fset.TotalHookCount.Value :
                           fset.TotalHooksObserved.HasValue ? (decimal)fset.TotalHooksObserved.Value :
                           fset.EstimatedHookCount.HasValue ? (decimal)fset.EstimatedHookCount.Value :
                           0M
                ).Sum() / 100M;
            }
        }

        public virtual void AddFishingSet(LongLineSet fset)
        {
            if (null == fset)
                return;

            fset.Trip = this;
            this.FishingSets.Add(fset);
        }
    }
}
