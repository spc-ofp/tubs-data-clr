﻿// -----------------------------------------------------------------------
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
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Infrastructure;
    using Spc.Ofp.Tubs.DAL.Security;
    using Newtonsoft.Json;

    /// <summary>
    /// Generic trip representation.
    /// </summary>
    public abstract class Trip : IAuditable, IEntity, ISecurable
    {
        public static readonly Expression<Func<Trip, string, bool>> IsAllowedExpression =
            (x, name) => x.AccessControl.Where(ace => name.Equals(ace.EntityName, StringComparison.InvariantCultureIgnoreCase)).Any();

        private static readonly Func<Trip, string, bool> IsAllowedFunc = IsAllowedExpression.Compile();
        
        protected Trip()
        {
            this.Sightings = new List<Sighting>(32);
            this.Transfers = new List<Transfer>(16);
            this.PollutionEvents = new List<PollutionEvent>();
            this.Electronics = new List<ElectronicDevice>(8);
            //this.Interactions = new List<SpecialSpeciesInteraction>();
            this.Interactions = new List<Interaction>();
            this.MultiLandingInteractions = new List<MultiLandingInteraction>();
            this.PageCounts = new List<PageCount>(12);
            this.Pushpins = new List<Pushpin>(180);
            // Create with default values as, in general, most data will be 2007 or earlier workbooks
            this.Gen3Answers = new List<Gen3Answer>();
            this.Gen3Details = new List<Gen3Detail>();
            this.AccessControl = new List<TripAce>(6);
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

        [DataType(DataType.Date)]
        [Display(ResourceType = typeof(FieldNames), Name = "VesselDepartureDate")]
        public virtual DateTime? VesselDepartureDate { get; set; }

        // TODO  Use a Regex for validation
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

        [Display(ResourceType = typeof(FieldNames), Name = "VesselDeparturePort")]
        public virtual Port VesselDeparturePort { get; set; }

        [RegularExpression(@"^[0-8]\d{3}[NnSs]$",
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "ShortLatitudeError")]
        public virtual string ObserverDepartureLatitude { get; set; }

        [RegularExpression(@"^[0-1]\d{4}[EeWw]$",
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "ShortLongitudeError")]
        public virtual string ObserverDepartureLongitude { get; set; }

        [RegularExpression(@"^[0-8]\d{3}[NnSs]$",
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "ShortLatitudeError")]
        public virtual string ObserverReturnLatitude { get; set; }

        [RegularExpression(@"^[0-1]\d{4}[EeWw]$",
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "ShortLongitudeError")]
        public virtual string ObserverReturnLongitude { get; set; }

        [EnumDataType(typeof(WorkbookVersion))]
        public virtual WorkbookVersion? Version { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HasWasteDisposal")]
        public virtual bool? HasWasteDisposal { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "WasteDisposalDescription")]
        public virtual string WasteDisposalDescription { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? EnteredDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UpdatedBy")]
        public virtual string UpdatedBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "UpdatedDate")]
        public virtual DateTime? UpdatedDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DctNotes")]
        [DataType(DataType.MultilineText)]
        public virtual string DctNotes { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DctScore")]
        public virtual int? DctScore { get; set; }

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

        public virtual DateTime? ReceivedDate { get; set; }

        public virtual DateTime? AcknowledgedDate { get; set; }

        public virtual bool? HasHardCopy { get; set; }

        public virtual int? RecordedSetCount { get; set; }

        public virtual int? CrewCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "WellCapacity")]
        [Range(0, 10000)]
        public virtual decimal? WellCapacity { get; set; }

        public virtual byte[] RowVersion { get; protected internal set; }

        public virtual IList<Sighting> Sightings { get; protected internal set; }

        public virtual IList<Transfer> Transfers { get; protected internal set; }

        public virtual IList<PollutionEvent> PollutionEvents { get; protected internal set; }

        // Pre-2009 GEN-3
        public virtual TripMonitor TripMonitor { get; set; } // Only one GEN-3 per trip.

        public virtual CommunicationServices CommunicationServices { get; set; }

        public virtual IList<ElectronicDevice> Electronics { get; protected internal set; }

        //public virtual IList<SpecialSpeciesInteraction> Interactions { get; protected internal set; }
        public virtual IList<Interaction> Interactions { get; protected internal set; }

        public virtual IList<MultiLandingInteraction> MultiLandingInteractions { get; protected internal set; }

        public virtual SafetyInspection Inspection { get; set; }

        public virtual IList<PageCount> PageCounts { get; protected internal set; }

        // Pushpins is a collection of derived values
        [JsonIgnore]
        public virtual IList<Pushpin> Pushpins { get; protected internal set; }

        // Don't export security
        [JsonIgnore]
        public virtual IList<TripAce> AccessControl { get; protected internal set; }

        // Don't export security
        [JsonIgnore]
        public virtual IEnumerable<IAccessControl> AccessControlList
        {
            get
            {
                return null == this.AccessControl ?
                    Enumerable.Empty<IAccessControl>() :
                    this.AccessControl.Cast<IAccessControl>();
            }
        }

        public virtual bool IsAllowed(string entityName)
        {
            return IsAllowedFunc(this, entityName);
        }

        // Workbook 2009 GEN-3
        public virtual IList<Gen3Answer> Gen3Answers { get; protected internal set; }

        // Workbook 2009 GEN-3
        public virtual IList<Gen3Detail> Gen3Details { get; protected internal set; }

        // Trip knows how to create it's own metrics
        // TODO Implement!  This is here as a reminder on how to implement the API
        public virtual object CatchAndEffort { get; protected set; }

        public abstract Gear GetGear();

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
            if (null == sighting)
                return;
            
            sighting.Trip = this;
            this.Sightings.Add(sighting);
        }

        public virtual void AddTransfer(Transfer transfer)
        {
            if (null == transfer)
                return;
            
            transfer.Trip = this;
            this.Transfers.Add(transfer);
        }

        public virtual void AddPollutionEvent(PollutionEvent pevent)
        {
            if (null == pevent)
                return;
            
            pevent.Trip = this;
            this.PollutionEvents.Add(pevent);
        }

        public virtual void AddElectronicDevice(ElectronicDevice device)
        {
            if (null == device)
                return;
            
            device.Trip = this;
            this.Electronics.Add(device);
        }

        public virtual void AddInteraction(Interaction interaction)
        {
            if (null == interaction)
                return;

            interaction.Trip = this;
            this.Interactions.Add(interaction);
        }

        public virtual void AddMultiLandingInteraction(MultiLandingInteraction interaction)
        {
            if (null == interaction)
                return;
            
            interaction.Trip = this;
            this.MultiLandingInteractions.Add(interaction);
        }

        public virtual void AddPageCount(PageCount pageCount)
        {
            if (null == pageCount)
                return;
            
            pageCount.Trip = this;
            this.PageCounts.Add(pageCount);
        }

        public virtual void AddPushpin(Pushpin pushpin)
        {
            if (null == pushpin)
                return;
            
            pushpin.Trip = this;
            this.Pushpins.Add(pushpin);
        }

        public virtual void AddGen3Answer(Gen3Answer answer)
        {
            if (null == answer)
                return;
            
            answer.Trip = this;
            this.Gen3Answers.Add(answer);
        }

        public virtual void AddGen3Detail(Gen3Detail detail)
        {
            if (null == detail)
                return;
            
            detail.Trip = this;
            this.Gen3Details.Add(detail);
        }

        public virtual string AlternateTripNumber
        {
            get
            {
                return CkTripNumber ?? FmTripNumber ?? FfaTripNumber ?? SbTripNumber ?? HwTripNumber ?? "N/A";
            }
        }

        /// <summary>
        /// Get the length of the trip in days.
        /// </summary>
        public virtual int LengthInDays
        {
            get
            {
                if (!this.DepartureDate.HasValue || !this.ReturnDate.HasValue)
                    return 0;

                var dep = this.DepartureDate.Value;
                var ret = this.ReturnDate.Value;
                var diff = dep.Subtract(ret);
                return (int)Math.Abs(diff.TotalDays);
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

        /// <summary>
        /// Read only property for determining if the trip is Read-Only.
        /// (How meta!)
        /// </summary>
        public virtual bool IsReadOnly
        {
            get
            {
                return this.ClosedDate.HasValue;
            }
        }

        /// <summary>
        /// Sort electronics by usage, with most frequently used coming first, and least frequently used
        /// coming last.  This might be a little bit of a hack, in that it relies on the Usage enumeration
        /// to be ordered from best to worst in the definition.  If the Usage enum is modified with codes
        /// not in order, this won't work as expected.
        /// 
        /// NHibernate uses a special class which implements IList<> but can't be cast to
        /// List<>.
        /// Because of the protection level of the Electronics member, we can't re-order the list
        /// outside this DLL.
        /// NOTE:  This will force a fetch of all the electronics devices!
        /// </summary>
        public virtual void SortElectronics()
        {
            // Avoid messing with this if possible
            if (null != this.Electronics && this.Electronics.Count > 1 && this.Electronics.Where(e => null != e && e.Usage.HasValue).Any())
            {
                var electronics = this.Electronics.ToList();
                electronics.Sort(delegate(ElectronicDevice d1, ElectronicDevice d2)
                {
                    return Comparer<int?>.Default.Compare((int?)d1.Usage, (int?)d2.Usage);
                });
                // NOTE: The initial implementation replaced the existing list with
                // a generic list.  This _BROKE_ NHibernate, as it wanted to remove all the
                // electronics from the trip on _display_.
                // This is a reasonable fix, given that SortElectronics() will only be called
                // in very limited circumstances.
                this.Electronics.Clear();
                electronics.ForEach(e => this.Electronics.Add(e));
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

        public virtual bool HasAcl()
        {
            return true;
        }

        public virtual bool IsNew()
        {
            return default(int) == this.Id;
        }

        public virtual object GetPkid()
        {
            return this.Id;
        }

        public virtual void SetAuditTrail(string userName, DateTime timestamp)
        {
            if (default(int) == this.Id)
            {
                this.EnteredBy = userName;
                this.EnteredDate = timestamp;
            }
            else
            {
                this.UpdatedBy = userName;
                this.UpdatedDate = timestamp;
            }
        }

    }
}
