// -----------------------------------------------------------------------
// <copyright file="Activity.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Activity represents a line item on the daily log form
    /// (e.g. PS-2 for purse seine trips, not sure what it is for
    /// pole and line trips...)
    /// </summary>
    public abstract class Activity
    {
        public virtual int Id { get; private set; }
        
        public virtual DateTime? LocalTime { get; set; }
        public virtual DateTime? UtcTime { get; set; } // Derived from UTC offset of local time
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }
        public virtual string EezCode { get; set; }
        public virtual ActivityType? ActivityType { get; set; }
        public virtual SchoolAssociation? SchoolAssociation { get; set; }
        public virtual DetectionMethod? DetectionMethod { get; set; }
        public virtual string Beacon { get; set; }
        public virtual string Comments { get; set; }
        // Audit trail
        public virtual string EnteredBy { get; set; }
        public virtual DateTime? EnteredDate { get; set; }

    }
}
