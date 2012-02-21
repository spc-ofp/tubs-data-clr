// -----------------------------------------------------------------------
// <copyright file="PurseSeineGear.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

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

        public virtual string NetDepthUnit { get; set; }

        public virtual int? NetDepthInMeters { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Length")]
        public virtual int? NetLength { get; set; }

        public virtual string NetLengthUnits { get; set; }

        public virtual int? NetLengthInMeters { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "NetStrips")]
        public virtual int? NetStrips { get; set; }

        public virtual int? NetHangRatio { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "MeshSize")]
        public virtual int? MeshSize { get; set; }

        public virtual string MeshSizeUnits { get; set; }

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
