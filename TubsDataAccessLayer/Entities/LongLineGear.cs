// -----------------------------------------------------------------------
// <copyright file="LongLineGear.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
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
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// LongLine gear.  This is constant for a trip, but some vessel gear can change
    /// from trip to trip.
    /// </summary>
    public class LongLineGear : Gear
    {
        // TODO Consider a class for Has/Usage/Comments data
        public virtual bool? HasMainlineHauler { get; set; }

        public virtual UsageCode? MainlineHaulerUsage { get; set; }

        public virtual string MainlineHaulerComments { get; set; }

        public virtual bool? HasBranchlineHauler { get; set; }

        public virtual UsageCode? BranchlineHaulerUsage { get; set; }

        public virtual string BranchlineHaulerComments { get; set; }

        public virtual bool? HasLineShooter { get; set; }

        public virtual UsageCode? LineShooterUsage { get; set; }

        public virtual string LineShooterComments { get; set; }

        public virtual bool? HasBaitThrower { get; set; }

        public virtual UsageCode? BaitThrowerUsage { get; set; }

        public virtual string BaitThrowerComments { get; set; }

        public virtual bool? HasBranchlineAttacher { get; set; }

        public virtual UsageCode? BranchlineAttacherUsage { get; set; }

        public virtual string BranchlineAttacherComments { get; set; }

        public virtual bool? HasWeightScales { get; set; }

        public virtual UsageCode? WeightScalesUsage { get; set; }

        public virtual string WeightScalesComments { get; set; }

        public virtual string MainlineComposition { get; set; }

        public virtual string BranchlineComposition { get; set; }

        public virtual string MainlineMaterial { get; set; }

        public virtual string MainlineMaterialDescription { get; set; }

        public virtual decimal? MainlineLength { get; set; }

        public virtual decimal? MainlineDiameter { get; set; }

        public virtual string BranchlineMaterial1 { get; set; }

        public virtual string BranchlineMaterial1Description { get; set; }

        public virtual string BranchlineMaterial2 { get; set; }

        public virtual string BranchlineMaterial2Description { get; set; }

        public virtual string BranchlineMaterial3 { get; set; }

        public virtual string BranchlineMaterial3Description { get; set; }

        public virtual bool? HasWireTrace { get; set; }

        public virtual bool? HasRefrigeratedSeawater { get; set; }

        public virtual bool? HasIce { get; set; }

        public virtual bool? HasBlastFreezer { get; set; }

        public virtual bool? HasChilledSeawater { get; set; }

        public virtual bool? HasOtherStorage { get; set; }

        public virtual string OtherStorageDescription { get; set; }

        public virtual string JapanHookSize { get; set; }

        public virtual int? JapanHookPercentage { get; set; }

        public virtual string CircleHookSize { get; set; }

        public virtual int? CircleHookPercentage { get; set; }

        public virtual string JHookSize { get; set; }

        public virtual int? JHookPercentage { get; set; }

        public virtual string OtherHookType { get; set; }

        public virtual string OtherHookSize { get; set; }

        public virtual int? OtherHookPercentage { get; set; }
    }
}
