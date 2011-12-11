// -----------------------------------------------------------------------
// <copyright file="Observer.cs" company="">
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
    /// Observer entity.  Sourced from the [ref].[field_staff] view and therefore
    /// read only.
    /// </summary>
    public class Observer
    {
        public virtual string StaffCode { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<Trip> Trips { get; set; }

        public Observer()
        {
            Trips = new List<Trip>();
        }

        public virtual void AddTrip(Trip trip)
        {
            trip.Observer = this;
            Trips.Add(trip);
        }
    }
}
