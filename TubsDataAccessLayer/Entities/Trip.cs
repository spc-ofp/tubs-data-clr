// -----------------------------------------------------------------------
// <copyright file="Trip.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Tubs.DAL.Entities
{
    /*
     * This file is part of TUBS.
     *
     * TUBS is free software: you can redistribute it and/or modify
     * it under the terms of the GNU Affero General Public License as published by
     * the Free Software Foundation, either version 3 of the License, or
     * (at your option) any later version.
     *  
     * TUBS is distributed in the hope that it will be useful,
     * but WITHOUT ANY WARRANTY; without even the implied warranty of
     * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
     * GNU Affero General Public License for more details.
     *  
     * You should have received a copy of the GNU Affero General Public License
     * along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
     */
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Generic trip representation.
    /// </summary>
    public abstract class Trip
    {
        protected Trip()
        {
            this.Sightings = new List<Sighting>(32);
            this.Transfers = new List<Transfer>(16);
            this.PollutionEvents = new List<PollutionEvent>();
            this.Electronics = new List<ElectronicDevice>(8);
            this.Interactions = new List<SpecialSpeciesInteraction>();
        }
        
        public virtual int Id { get; protected set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DepartureDate")]
        public virtual DateTime? DepartureDate { get; set; }

        public virtual DateTime? DepartureDateOnly { get; set; }

        public virtual string DepartureTimeOnly { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UtcDepartureDate")]
        public virtual DateTime? UtcDepartureDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ReturnDate")]
        public virtual DateTime? ReturnDate { get; set; }

        public virtual DateTime? ReturnDateOnly { get; set; }

        public virtual string ReturnTimeOnly { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TripNumber")]
        public virtual string TripNumber { get; set; }

        public virtual Vessel Vessel { get; set; }

        public virtual Observer Observer { get; set; }

        public virtual Port DeparturePort { get; set; }

        public virtual Port ReturnPort { get; set; }

        public virtual WorkbookVersion? Version { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        public virtual DateTime? EnteredDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ProgramCode")]
        public virtual ObserverProgram ProgramCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "CountryCode")]
        public virtual string CountryCode { get; set; }

        // Trip knows how to create it's own metrics
        // TODO Implement!  This is here as a reminder on how to implement the API
        public virtual object CatchAndEffort { get; protected set; }

        public virtual IList<Sighting> Sightings { get; protected internal set; }

        public virtual IList<Transfer> Transfers { get; protected internal set; }

        public virtual IList<PollutionEvent> PollutionEvents { get; protected internal set; }

        public virtual TripMonitor TripMonitor { get; set; } // Only one GEN-3 per trip.  TODO Do we need to add backref to 'set' method?

        public virtual CommunicationServices CommunicationServices { get; set; }

        public virtual IList<ElectronicDevice> Electronics { get; protected internal set; }

        public virtual IList<SpecialSpeciesInteraction> Interactions { get; protected internal set; }

        public virtual SafetyInspection Inspection { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            return builder.ToString();
        }

        public virtual void AddSighting(Sighting sighting)
        {
            sighting.Trip = this;
            this.Sightings.Add(sighting);
        }

        public virtual void AddTransfer(Transfer transfer)
        {
            transfer.Trip = this;
            this.Transfers.Add(transfer);
        }

        public virtual void AddPollutionEvent(PollutionEvent pevent)
        {
            pevent.Trip = this;
            this.PollutionEvents.Add(pevent);
        }

        public virtual void AddElectronicDevice(ElectronicDevice device)
        {
            device.Trip = this;
            this.Electronics.Add(device);
        }

        public virtual void AddInteraction(SpecialSpeciesInteraction interaction)
        {
            interaction.Trip = this;
            this.Interactions.Add(interaction);
        }

        public virtual void NormalizeDates()
        {
            if (this.DepartureDate.HasValue && !this.DepartureDateOnly.HasValue)
            {

            }
        }

    }
}
