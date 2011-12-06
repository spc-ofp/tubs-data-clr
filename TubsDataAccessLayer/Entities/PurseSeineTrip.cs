// -----------------------------------------------------------------------
// <copyright file="PurseSeineTrip.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PurseSeineTrip : Trip
    {
        public virtual IList<PurseSeineSeaDay> SeaDays { get; set; }

        public PurseSeineTrip()
        {
            SeaDays = new List<PurseSeineSeaDay>();
        }

        public virtual void AddSeaDay(PurseSeineSeaDay seaday)
        {
            seaday.Trip = this; // Change to Trip?
            SeaDays.Add(seaday);
        }
    }
}
