// -----------------------------------------------------------------------
// <copyright file="PurseSeineSet.cs" company="">
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
    public class PurseSeineSet
    {
        public virtual int Id { get; private set; }
        public virtual PurseSeineActivity Activity { get; set; }
        public virtual int? SetNumber { get; set; }
        public virtual DateTime? StartOfSetFromVesselLog { get; set; }
        public virtual DateTime? StartOfSet { get; set; }

        public virtual DateTime? SkiffOff { get; set; }
        public virtual DateTime? WinchOn { get; set; }
        public virtual DateTime? RingsUp { get; set; }
        public virtual DateTime? BeginBrailing { get; set; }
        public virtual DateTime? EndBrailing { get; set; }
        public virtual DateTime? EndOfSet { get; set; }


    }
}
