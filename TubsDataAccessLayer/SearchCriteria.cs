// -----------------------------------------------------------------------
// <copyright file="SearchCriteria.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL
{
    using System;

    /// <summary>
    /// Container class for search criteria.
    /// </summary>
    public class SearchCriteria
    {
        public string Observer { get; set; }

        public string ProgramCode { get; set; }

        public string Vessel { get; set; }

        public string VesselCountryCode { get; set; }

        public string DeparturePort { get; set; }

        public string ReturnPort { get; set; }

        public string AnyPort { get; set; }

        public DateTime? DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime? AnyDate { get; set; }

        public bool IsValid()
        {
            return
                !string.IsNullOrEmpty(this.Observer) ||
                !string.IsNullOrEmpty(this.ProgramCode) ||
                !string.IsNullOrEmpty(this.Vessel) ||
                !string.IsNullOrEmpty(this.VesselCountryCode) ||
                !string.IsNullOrEmpty(this.DeparturePort) ||
                !string.IsNullOrEmpty(this.ReturnPort) ||
                !string.IsNullOrEmpty(this.AnyPort) ||
                this.DepartureDate.HasValue ||
                this.ReturnDate.HasValue ||
                this.AnyDate.HasValue;
        }
    }
}
