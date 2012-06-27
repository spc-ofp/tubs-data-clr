// -----------------------------------------------------------------------
// <copyright file="PurseSeineGear.cs" company="Secretariat of the Pacific Community">
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
    using System;
    using System.ComponentModel.DataAnnotations;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Purse Seine gear.  This is constant for a trip, but some vessel gear can change
    /// from trip to trip.
    /// </summary>
    public class PurseSeineGear : Gear
    {
        [Display(ResourceType = typeof(FieldNames), Name = "Make")]
        public virtual string PowerblockMake { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Model")]
        public virtual string PowerblockModel { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Power")]
        public virtual int? PowerblockPower { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Speed")]
        public virtual int? PowerblockSpeed { get; set;}

        [Display(ResourceType = typeof(FieldNames), Name = "Make")]
        public virtual string PurseWinchMake { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Model")]
        public virtual string PurseWinchModel { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Power")]
        public virtual int? PurseWinchPower { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Speed")]
        public virtual int? PurseWinchSpeed { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Depth")]
        public virtual int? NetDepth { get; set; }

        public virtual UnitOfMeasure? NetDepthUnit { get; set; }

        public virtual int? NetDepthInMeters { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Length")]
        public virtual int? NetLength { get; set; }

        public virtual UnitOfMeasure? NetLengthUnits { get; set; }

        public virtual int? NetLengthInMeters { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "NetStrips")]
        public virtual int? NetStrips { get; set; }

        public virtual int? NetHangRatio { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "MeshSize")]
        public virtual int? MeshSize { get; set; }

        public virtual UnitOfMeasure? MeshSizeUnits { get; set; }

        public virtual int? MeshSizeInCm { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Brail1Size")]
        public virtual decimal? Brail1Size { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Brail2Size")]
        public virtual decimal? Brail2Size { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "BrailType")]
        [DataType(DataType.MultilineText)]
        public virtual string BrailType { get; set; }
    }
}
