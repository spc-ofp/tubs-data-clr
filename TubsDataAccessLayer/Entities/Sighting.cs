// -----------------------------------------------------------------------
// <copyright file="Sighting.cs" company="Secretariat of the Pacific Community">
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
    using System.ComponentModel.DataAnnotations;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Sighting represents a vessel sighting recorded on form GEN-1.
    /// </summary>
    public class Sighting
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual int? FormId { get; set; }

        public virtual DateTime? EventTime { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Latitude")]
        public virtual string Latitude { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Longitude")]
        public virtual string Longitude { get; set; }

        public virtual SightedVesselType? VesselType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Bearing")]
        [Range(0d, 360d)]
        public virtual int? Bearing { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Distance")]
        public virtual decimal? Distance { get; set; }

        public virtual string DistanceUnit { get; set; }

        public virtual ActionType? ActionType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "PhotoNumber")]
        public virtual string PhotoNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        public virtual string Comments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        public virtual DateTime? EnteredDate { get; set; }
    }
}
