// -----------------------------------------------------------------------
// <copyright file="SeaDay.cs" company="">
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
    /// TODO: Update summary.
    /// </summary>
    public class PurseSeineSeaDay : SeaDay
    {
        public virtual string DiaryPage { get; set; }
        public virtual IList<PurseSeineActivity> Activities { get; set; }

        public PurseSeineSeaDay()
        {
            Activities = new List<PurseSeineActivity>();
        }

        public virtual void AddActivity(PurseSeineActivity activity)
        {
            activity.Day = this;
            Activities.Add(activity);
        }
    }
}
