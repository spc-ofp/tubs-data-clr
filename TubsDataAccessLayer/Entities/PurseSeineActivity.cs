// -----------------------------------------------------------------------
// <copyright file="PurseSeineActivity.cs" company="">
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
    public class PurseSeineActivity : Activity
    {
        public virtual PurseSeineSeaDay Day { get; set; }
        public virtual decimal? FishDays { get; set; } // ???
        
        public virtual string Payao { get; set; }
        public virtual int WindDirection { get; set; }
        public virtual int WindSpeed { get; set; }
        public virtual string SeaCode { get; set; }
    }
}
