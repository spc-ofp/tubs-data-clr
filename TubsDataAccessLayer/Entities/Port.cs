// -----------------------------------------------------------------------
// <copyright file="Port.cs" company="">
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
    public class Port
    {
        public virtual string PortCode { get; set; }
        public virtual string Name { get; set; }
        public virtual string AlternateName { get; set; }
        public virtual string CountryCode { get; set; }
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }
    }
}
