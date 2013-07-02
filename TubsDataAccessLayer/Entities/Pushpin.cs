// -----------------------------------------------------------------------
// <copyright file="Pushpin.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Pushpin is a lightweight, readonly class that provides the
    /// position in space and time for a given trip.
    /// </summary>
    public class Pushpin
    {
        public const string FindByTrip =
            @"SELECT " +
            "    lat as [Latitude], " +
            "    lon as [Longitude], " +
            "    tstamp as [Timestamp], " +
            "    event_description as [Description], " +
            "    event_key as [EventKey] " +
            "FROM obsv.vw_positions WHERE obstrip_id = ? " +
            "ORDER BY tstamp ASC";

        public virtual string FormName { get; set; }

        public virtual int EventKey { get; set; }

        public virtual Trip Trip { get; set; }
        
        public virtual decimal? Latitude { get; set; }

        public virtual decimal? Longitude { get; set; }

        public virtual DateTime? Timestamp { get; set; }

        public virtual string Description { get; set; }

        public override bool Equals(object obj)
        {
            if (null == obj)
            {
                return false;
            }

            var rhs = obj as Pushpin;
            if (null == rhs)
            {
                return false;
            }

            return this.FormName.Equals(rhs.FormName) && this.EventKey == rhs.EventKey;
        }

        public override int GetHashCode()
        {
            return String.Format("{0}:{1}", this.FormName, this.EventKey).GetHashCode();
        }

        
    }
}
