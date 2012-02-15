// -----------------------------------------------------------------------
// <copyright file="ConstraintEventListener.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using NHibernate.Event;
    using NHibernate.Persister.Entity;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// ConstraintEventListener manages Observer/Trip Number constraints for Trips.
    /// For more details on how this works, see:
    /// http://geekswithblogs.net/robz/archive/2009/11/18/nhibernate-event-listener-registration-with-fluent-nhibernate.aspx
    /// http://ayende.com/blog/3987/nhibernate-ipreupdateeventlistener-ipreinserteventlistener
    /// http://toranbillups.com/blog/archive/2009/09/24/How-to-validate-your-domain-model-when-using-NHibernate
    /// </summary>
    public class ConstraintEventListener : IPreInsertEventListener, IPreUpdateEventListener
    {
        private static bool ViolatesTripConstraint(ISession session, string staffCode, string tripNumber, int id)
        {
            var trip = session.QueryOver<Trip>().Where(t => t.Observer.StaffCode == staffCode && t.TripNumber == tripNumber).SingleOrDefault();
            if (null == trip)
            {
                return false;
            }
            return id != trip.Id;
        }


        public bool OnPreInsert(PreInsertEvent eventItem)
        {
            Trip trip = eventItem.Entity as Trip;
            if (null == trip)
            {
                return false;
            }

            if (ViolatesTripConstraint(eventItem.Session, trip.Observer.StaffCode, trip.TripNumber, trip.Id))
            {
                throw new Exception("Trip with this staff code/trip number already exists.");
            }

            // Mess with Departure/Return dates
            if (trip.DepartureDate.HasValue && !trip.DepartureDateOnly.HasValue)
            {
                // Set DateOnly to midnight
                trip.DepartureDateOnly = trip.DepartureDate.Value.Subtract(trip.DepartureDate.Value.TimeOfDay);
            }

            if (trip.ReturnDate.HasValue && !trip.ReturnDateOnly.HasValue)
            {
                // Set DateOnly to midnight
                trip.ReturnDateOnly = trip.ReturnDate.Value.Subtract(trip.ReturnDate.Value.TimeOfDay);
            }

            return false;
        }



        public bool OnPreUpdate(PreUpdateEvent eventItem)
        {
            Trip trip = eventItem.Entity as Trip;
            if (null == trip)
            {
                return false;
            }

            if (ViolatesTripConstraint(eventItem.Session, trip.Observer.StaffCode, trip.TripNumber, trip.Id))
            {
                throw new Exception("Trip with this staff code/trip number already exists.");
            }

            // Mess with Departure/Return dates?

            return false;
        }
    }
}
