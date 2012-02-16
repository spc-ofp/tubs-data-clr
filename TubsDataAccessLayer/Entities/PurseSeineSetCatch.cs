// -----------------------------------------------------------------------
// <copyright file="PurseSeineSetCatch.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PurseSeineSetCatch : SetCatch
    {
        public virtual PurseSeineSet FishingSet { get; set; }

        public virtual bool? ContainsLargeFish { get; set; }

        public virtual string ConditionCode { get; set; }

        public virtual decimal? MetricTonsObserved { get; set; }

        public virtual decimal? MetricTonsFromLog { get; set; }

        public virtual int? CountObserved { get; set; }

        public virtual int? CountFromLog { get; set; }

        public virtual decimal? CalculatedSpeciesCatch { get; set; } // ???

        public virtual int? AverageWeightMethodId { get; set; }

        public virtual decimal? EstimatedSpeciesCatch { get; set; }

        public virtual int? CatchWeightMethodId { get; set; }

        public virtual int? EstimatedSpeciesCount { get; set; }

        public virtual decimal? SpeciesWeightLow { get; set; }

        public virtual decimal? SpeciesWeightHigh { get; set; }
    }
}
