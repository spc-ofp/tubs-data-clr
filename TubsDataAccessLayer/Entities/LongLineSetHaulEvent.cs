// -----------------------------------------------------------------------
// <copyright file="LongLineSetHaulEvent.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TODO: It would be interesting to split this into a LongLineSetEvent and a LongLineHaulEvent
    /// (with an abstract base LongLineEvent class)
    /// </summary>
    public class LongLineSetHaulEvent
    {
        public virtual int Id { get; set; }

        public virtual LongLineSet FishingSet { get; set; }

        public virtual DateTime? LogDateOnly { get; set; }

        public virtual string LogTimeOnly { get; set; }

        public virtual DateTime? LogDate { get; set; }

        // S for Setting, H for Hauling.  Probably want to rework this...
        public virtual string Sethaul { get; set; }

        /// <summary>
        /// Get or set the value of ActivityType.
        /// ActivityType can be null, which marks an intermediate haul event
        /// </summary>
        [EnumDataType(typeof(HaulActivityType))]
        public virtual HaulActivityType? ActivityType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Latitude")]
        [RegularExpression(@"^[0-8]\d{3}\.?\d{3}[NnSs]$",
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "LatitudeError")]
        public virtual string Latitude { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Longitude")]
        [RegularExpression(@"^[0-1]\d{4}\.?\d{3}[EeWw]$",
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "LongitudeError")]
        public virtual string Longitude { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EezId")]
        public virtual string EezCode { get; set; }

        [Range(0, 360)]
        [Display(ResourceType = typeof(FieldNames), Name = "WindDirection")]
        public virtual int? WindDirection { get; set; }

        [Range(0, Int32.MaxValue)]
        [Display(ResourceType = typeof(FieldNames), Name = "WindSpeed")]
        public virtual int? WindSpeed { get; set; }

        [EnumDataType(typeof(SeaCode))]
        [Display(ResourceType = typeof(FieldNames), Name = "SeaCode")]
        public virtual SeaCode? SeaCode { get; set; }

        public virtual int? CloudCover { get; set; }

        public virtual string Comments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        public virtual DateTime? EnteredDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UpdatedBy")]
        public virtual string UpdatedBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UpdatedDate")]
        public virtual DateTime? UpdatedDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DctNotes")]
        [DataType(DataType.MultilineText)]
        public virtual string DctNotes { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DctScore")]
        public virtual int? DctScore { get; set; }

        
        public static void SetStartAndEnd(IList<LongLineSetHaulEvent> events)
        {
            // Ignore invalid lists
            if (null == events || events.Count < 2)
                return;

            // Don't forget to test this with some null LogDate values...
            var sortedByDate = events.Where(e => e != null && e.LogDate.HasValue).OrderBy(e => e.LogDate);

            // Operate on Setting events
            var settingEvents = sortedByDate.Where(e => "S".Equals(e.Sethaul, StringComparison.InvariantCultureIgnoreCase));
            if (settingEvents.Count() >= 2)
            {
                settingEvents.First().ActivityType = HaulActivityType.StartOfSet;
                settingEvents.Last().ActivityType = HaulActivityType.EndOfSet;
            }

            // Operate on Hauling events
            var haulingEvents = sortedByDate.Where(e => "H".Equals(e.Sethaul, StringComparison.InvariantCultureIgnoreCase));
            if (haulingEvents.Count() >= 2)
            {
                haulingEvents.First().ActivityType = HaulActivityType.StartOfHaul;
                haulingEvents.Last().ActivityType = HaulActivityType.EndOfHaul;
            }

        }
    }
}
