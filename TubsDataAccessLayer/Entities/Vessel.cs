// -----------------------------------------------------------------------
// <copyright file="Vessel.cs" company="">
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
    public class Vessel
    {
        public virtual int Id { get; private set; }
        public virtual string TypeCode { get; set; } // TODO Enum?
        public virtual string Name { get; set; }
        public virtual string WcpfcNumber { get; set; }
        public virtual string Ircs { get; set; }
        public virtual string RegisteredCountryCode { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual float? GrossTonnage { get; set; }
        public virtual float? Length { get; set; }
        public virtual int? YearBuilt { get; set; }
        public virtual decimal? EnginePower { get; set; }
        public virtual string EnginePowerUnits { get; set; }

        // Audit trail
        public virtual string EnteredBy { get; set; }
        public virtual DateTime? EnteredDate { get; set; }
    }
}
