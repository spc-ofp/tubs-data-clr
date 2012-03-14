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
            this.PageCounts = new List<PageCount>(12);
            this.Pushpins = new List<Pushpin>(180);
        }
        
        public virtual int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof(FieldNames), Name = "DepartureDate")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? DepartureDate { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? DepartureDateOnly { get; set; }

        public virtual string DepartureTimeOnly { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UtcDepartureDate")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? UtcDepartureDate { get; set; }

        [Required]
        [Display(ResourceType = typeof(FieldNames), Name = "ReturnDate")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? ReturnDate { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? ReturnDateOnly { get; set; }

        public virtual string ReturnTimeOnly { get; set; }

        // TODO?  Use a Regex?
        [Display(ResourceType = typeof(FieldNames), Name = "TripNumber")]
        public virtual string TripNumber { get; set; }

        [Required]
        public virtual Vessel Vessel { get; set; }

        public virtual VesselNotes VesselNotes { get; set; }

        [Required]
        public virtual Observer Observer { get; set; }

        [Required]
        public virtual Port DeparturePort { get; set; }

        [Required]
        public virtual Port ReturnPort { get; set; }

        [EnumDataType(typeof(WorkbookVersion))]
        public virtual WorkbookVersion? Version { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? EnteredDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ClosedDate")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? ClosedDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VerifiedBy")]
        public virtual string VerifiedBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "VerifiedDate")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? VerifiedDate { get; set; }

        [Required]
        [Display(ResourceType = typeof(FieldNames), Name = "ProgramCode")]
        [EnumDataType(typeof(ObserverProgram))]
        public virtual ObserverProgram ProgramCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "CountryCode")]
        [StringLength(2)]
        public virtual string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the value of RegistrationId.
        /// RegistrationId links a trip in TUBS with the packet of physical documents
        /// it came from.
        /// </summary>
        public virtual int? RegistrationId { get; set; }

        /// <summary>
        /// Gets or sets the value of CkTripNumber.
        /// CkTripNumber is the alternate trip number for trips from ???
        /// </summary>
        [StringLength(11)]
        public virtual string CkTripNumber { get; set; }

        /// <summary>
        /// Gets or sets the value of FmTripNumber.
        /// FmTripNumber is the alternate trip number for trips from ???
        /// </summary>
        [StringLength(5)]
        public virtual string FmTripNumber { get; set; }

        /// <summary>
        /// Gets or sets the value of FfaTripNumber.
        /// FfaTripNumber is the alternate trip number for trips from FFA.
        /// TODO?  Use a Regex?
        /// </summary>
        [StringLength(10)]
        public virtual string FfaTripNumber { get; set; }

        /// <summary>
        /// Gets or sets the value of SbTripNumber.
        /// SbTripNumber is the alternate trip number for trips from Solomon Islands fisheries.
        /// </summary>
        [StringLength(6)]
        public virtual string SbTripNumber { get; set; }

        /// <summary>
        /// Gets or sets the value of HwTripNumber.
        /// HwTripNumber is the alternate trip number for trips from ???
        /// </summary>
        [StringLength(6)]
        public virtual string HwTripNumber { get; set; }

        public virtual bool? IsSharkTarget { get; set; }

        public virtual bool? IsFullTrip { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        public virtual string Comments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ProjectCode")]
        [StringLength(20)]
        public virtual string ProjectCode { get; set; }

        public virtual bool? IsCadetTrip { get; set; }

        public virtual bool? IsSpillSampled { get; set; }

        // FIXME SpillObserver still uses int
        //public virtual Observer SpillObserver { get; set; }

        [StringLength(10)]
        public virtual string SpillTripNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "WellCapacity")]
        [Range(0, 10000)]
        public virtual decimal? WellCapacity { get; set; }

        public virtual byte[] RowVersion { get; protected internal set; }

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

        public virtual IList<PageCount> PageCounts { get; protected internal set; }

        public virtual IList<Pushpin> Pushpins { get; protected internal set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            var tripType = this.GetType();
            if (typeof(PurseSeineTrip) == tripType)
            {
                builder.Append("Purse Seine ");
            }
            else if (typeof(LongLineTrip) == tripType)
            {
                builder.Append("Long Line ");
            }
            else if (typeof(PoleAndLineTrip) == tripType)
            {
                builder.Append("Pole and Line ");
            }
            else
            {
                builder.Append("Unknown type ");
            }
            builder.Append("trip ").Append(SpcTripNumber);
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

        public virtual void AddPageCount(PageCount pageCount)
        {
            pageCount.Trip = this;
            this.PageCounts.Add(pageCount);
        }

        public virtual void AddPushpin(Pushpin pushpin)
        {
            pushpin.Trip = this;
            this.Pushpins.Add(pushpin);
        }

        public virtual string AlternateTripNumber
        {
            get
            {
                return CkTripNumber ?? FmTripNumber ?? FfaTripNumber ?? SbTripNumber ?? HwTripNumber ?? "N/A";
            }
        }

        public virtual string SpcTripNumber
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                // Shouldn't be necessary, but it never hurts to guard against an NPE
                if (null != this.Observer)
                {
                    builder.Append(this.Observer.StaffCode).Append(" / ");
                }
                builder.Append(this.TripNumber);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Rather than mess around with date math, just ask the Trip object if a given date
        /// is between the departure and return dates.
        /// </summary>
        /// <param name="candidate">Date to be checked.</param>
        /// <returns>true if candidate Date falls between departure and return dates, false otherwise.</returns>
        public virtual bool IsDuringTrip(DateTime candidate)
        {
            long minValue = DepartureDate.HasValue ? DepartureDate.Value.Ticks : DepartureDateOnly.Value.Ticks;
            long maxValue = ReturnDate.HasValue ? ReturnDate.Value.Ticks : ReturnDateOnly.Value.Ticks;
            return candidate.Ticks >= minValue && candidate.Ticks <= maxValue;
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return this.ClosedDate.HasValue;
            }
        }

        // Unit test before deploying to TubsWeb
        public virtual void NormalizeDates()
        {
            if (this.DepartureDate.HasValue && !this.DepartureDateOnly.HasValue)
            {
                this.DepartureDateOnly = this.DepartureDate.Value.Subtract(this.DepartureDate.Value.TimeOfDay);
                this.DepartureTimeOnly = this.DepartureDate.Value.ToString("HHmm");
            }

            if (this.DepartureDateOnly.HasValue && !this.DepartureDate.HasValue)
            {
                this.DepartureDate = this.DepartureDateOnly.Merge(this.DepartureTimeOnly);
            }

            if (this.ReturnDate.HasValue && !this.ReturnDateOnly.HasValue)
            {
                this.ReturnDateOnly = this.ReturnDate.Value.Subtract(this.ReturnDate.Value.TimeOfDay);
                this.ReturnTimeOnly = this.ReturnDate.Value.ToString("HHmm");
            }

            if (this.ReturnDateOnly.HasValue && !this.ReturnDate.HasValue)
            {
                this.ReturnDate = this.ReturnDateOnly.Merge(this.ReturnTimeOnly);
            }
        }

    }
}
