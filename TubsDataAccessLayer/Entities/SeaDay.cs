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
    public abstract class SeaDay
    {
        public virtual int Id { get; private set; }
        public virtual Trip Trip { get; set; }
        public virtual int? FormId { get; set; }
        public virtual DateTime? StartOfDay { get; set; }
        public virtual DateTime? UtcStartOfDay { get; set; }

        public virtual int? FloatingObjectsNoSchool { get; set; }
        public virtual int? FloatingObjectsWithSchool { get; set; }
        public virtual int? FadsNoSchool { get; set; }
        public virtual int? FadsWithSchool { get; set; }
        public virtual int? FreeSchools { get; set; }

        public virtual bool? Gen3Events { get; set; }

        // Audit trail
        public virtual string EnteredBy { get; set; }
        public virtual DateTime? EnteredDate { get; set; }
    }
}
