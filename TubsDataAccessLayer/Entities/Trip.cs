// -----------------------------------------------------------------------
// <copyright file="Trip.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Generic trip representation.
    /// </summary>
    public abstract class Trip
    {
        public virtual int Id { get; private set; }
        public virtual DateTime? DepartureDate { get; set; }
        public virtual DateTime? UtcDepartureDate { get; set; }
        public virtual DateTime? ReturnDate { get; set; }
        public virtual string TripNumber { get; set; }

        public virtual Vessel Vessel { get; set; }
        public virtual Observer Observer { get; set; }

        public virtual Port DeparturePort { get; set; }
        public virtual Port ReturnPort { get; set; }

        // Audit trail
        public virtual string EnteredBy { get; set; }
        public virtual DateTime? EnteredDate { get; set; }
    }
}
