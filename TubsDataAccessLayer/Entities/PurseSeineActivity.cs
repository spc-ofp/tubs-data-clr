// -----------------------------------------------------------------------
// <copyright file="PurseSeineActivity.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Common;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PurseSeineActivity : Activity
    {
        public virtual PurseSeineSeaDay Day { get; set; }

        public virtual decimal? FishDays { get; set; } // ???
        
        public virtual string Payao { get; set; }

        [Range(0, 360)]
        [Display(ResourceType = typeof(FieldNames), Name = "WindDirection")]
        public virtual int? WindDirection { get; set; }

        [Range(0, Int32.MaxValue)]
        [Display(ResourceType = typeof(FieldNames), Name = "WindSpeed")]
        public virtual int? WindSpeed { get; set; }

        [EnumDataType(typeof(SeaCode))]
        [Display(ResourceType = typeof(FieldNames), Name = "SeaCode")]
        public virtual SeaCode? SeaCode { get; set; }

        // This should only happen when the activity code is ActivityType.Fishing
        public virtual PurseSeineSet FishingSet { get; set; }
    }
}
