// -----------------------------------------------------------------------
// <copyright file="PurseSeineGear.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;

    /// <summary>
    /// Purse Seine gear.  This is constant for a trip, but some vessel gear can change
    /// from trip to trip.
    /// </summary>
    public class PurseSeineGear
    {
        public virtual int Id { get; protected set; }

        public virtual Trip Trip { get; set; }

        public virtual string PowerblockMake { get; set; }

        public virtual string PowerblockModel { get; set; }

        public virtual int? PowerblockPower { get; set; }

        public virtual int? PowerblockSpeed { get; set;}

        public virtual string PurseWinchMake { get; set; }

        public virtual string PurseWinchModel { get; set; }

        public virtual int? PurseWinchPower { get; set; }

        public virtual int? PurseWinchSpeed { get; set; }

        public virtual int? NetDepth { get; set; }

        public virtual string NetDepthUnit { get; set; }

        public virtual int? NetDepthInMeters { get; set; }

        public virtual int? NetLength { get; set; }

        public virtual string NetLengthUnits { get; set; }

        public virtual int? NetLengthInMeters { get; set; }

        public virtual int? NetStrips { get; set; }

        public virtual int? NetHangRatio { get; set; }

        public virtual int? MeshSize { get; set; }

        public virtual string MeshSizeUnits { get; set; }

        public virtual int? MeshSizeInCm { get; set; }

        public virtual decimal? Brail1Size { get; set; }

        public virtual decimal? Brail2Size { get; set; }

        public virtual string BrailType { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }
    }
}
