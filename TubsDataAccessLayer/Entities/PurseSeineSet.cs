// -----------------------------------------------------------------------
// <copyright file="PurseSeineSet.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Purse seine set details as recorded on form PS-3
    /// </summary>
    public class PurseSeineSet : IAuditable
    {
        public PurseSeineSet()
        {
            this.CatchList = new List<PurseSeineSetCatch>();
            this.SamplingHeaders = new List<LengthSamplingHeader>();
        }

        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets reference back to the activity that led to this set
        /// </summary>
        public virtual PurseSeineActivity Activity { get; set; }

        /// <summary>
        /// Gets or sets set number with respect to the trip.  Should be monotonically increasing
        /// during the trip
        /// </summary>
        public virtual int? SetNumber { get; set; }

        /// <summary>
        /// Gets or sets time of set start as recorded in the vessel log
        /// </summary>
        public virtual DateTime? StartOfSetFromLog { get; set; }

        /// <summary>
        /// Gets or sets time the skiff leaves the boat (should be the same
        /// as start of set) as recorded by observer
        /// </summary>
        public virtual DateTime? SkiffOff { get; set; }

        public virtual string SkiffOffTimeOnly { get; set; }

        /// <summary>
        /// Gets or sets time at which pursing begins as recorded by the observer
        /// </summary>
        public virtual DateTime? WinchOn { get; set; }

        public virtual string WinchOnTimeOnly { get; set; }

        /// <summary>
        /// Gets or sets time at which pursing ends as recorded by the observer
        /// </summary>
        public virtual DateTime? RingsUp { get; set; }

        public virtual string RingsUpTimeOnly { get; set; }

        /// <summary>
        /// Gets or sets time that brailing begins as recorded by the observer
        /// </summary>
        public virtual DateTime? BeginBrailing { get; set; }

        public virtual string BeginBrailingTimeOnly { get; set; }

        /// <summary>
        /// Gets or sets time that brailing ends as recorded by the observer
        /// </summary>
        public virtual DateTime? EndBrailing { get; set; }

        public virtual string EndBrailingTimeOnly { get; set; }

        /// <summary>
        /// Gets or sets time at which the set is complete (skiff on board)
        /// as recorded by the observer
        /// </summary>
        public virtual DateTime? EndOfSet { get; set; }

        public virtual string EndOfSetTimeOnly { get; set; }

        /// <summary>
        /// Gets or sets onboard total weight before this set (observer)
        /// </summary>
        public virtual decimal? WeightOnboardObserved { get; set; }

        /// <summary>
        /// Gets or sets Onboard total weight before this set (vessel log)
        /// </summary>
        public virtual decimal? WeightOnboardFromLog { get; set; }

        /// <summary>
        /// Gets or sets total tonnage retained this set (observer)
        /// </summary>
        public virtual decimal? RetainedTonnageObserved { get; set; }

        /// <summary>
        /// Gets or sets total tonnage retained this set (vessel log)
        /// </summary>
        public virtual decimal? RetainedTonnageFromLog { get; set; }

        /// <summary>
        /// Is the value of 'RetainedTonnageFromLog' only from this
        /// set?
        /// </summary>
        public virtual bool? VesselTonnageOnlyFromThisSet { get; set; }

        /// <summary>
        /// Gets or sets the number of tons of catch that have just come on board
        /// as recorded by the observer
        /// </summary>
        public virtual decimal? NewOnboardTotalObserved { get; set; }

        /// <summary>
        /// Gets or sets the number of tons of catch that have just come on board
        /// as recorded in the vessel log
        /// </summary>
        public virtual decimal? NewOnboardTotalFromLog { get; set; }

        /// <summary>
        /// Gets or sets the number of tons of tuna in this set as recorded by the observer
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "TonsOfTunaObserved")]
        public virtual decimal? TonsOfTunaObserved { get; set; }

        /// <summary>
        /// Gets or sets the sum of all brails using brail #1
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "SumOfBrail1")]
        public virtual decimal? SumOfBrail1 { get; set; }

        /// <summary>
        /// Gets or sets the sum of all brails using brail #2
        /// </summary>
        [Display(ResourceType = typeof(FieldNames), Name = "SumOfBrail2")]
        public virtual decimal? SumOfBrail2 { get; set; }

        // One option is query substitutions:
        // http://stackoverflow.com/questions/7404991/fluentnhibernate-how-to-map-database-char-to-c-sharp-bool
        // Another option is a custom user type:
        // http://darrell.mozingo.net/2009/02/10/generic-nhibernate-user-type-base-class/

        /// <summary>
        /// Does this set contain Skipjack?
        /// </summary>
        public virtual bool? ContainsSkipjack { get; set; }

        /// <summary>
        /// Gets or sets the approximate percentage of skipjack in the total target catch
        /// </summary>
        public virtual int? SkipjackPercentage { get; set; }

        /// <summary>
        /// Gets or sets the number of tons of skipjack in the total target catch
        /// </summary>
        public virtual decimal? TonsOfSkipjackObserved { get; set; }

        /// <summary>
        /// Does this set contain Yellowfin?
        /// </summary>
        public virtual bool? ContainsYellowfin { get; set; }

        /// <summary>
        /// Gets or sets the approximate percentage of yellowfin in the total target catch
        /// </summary>
        public virtual int? YellowfinPercentage { get; set; }

        /// <summary>
        /// Gets or sets the number of tons of yellowfin in the total target catch
        /// </summary>
        public virtual decimal? TonsOfYellowfinObserved { get; set; }

        /// <summary>
        /// Does this set contain Bigeye?
        /// </summary>
        public virtual bool? ContainsBigeye { get; set; }

        /// <summary>
        /// Gets or sets the approximate percentage of yellowfin in the total target catch
        /// </summary>
        public virtual int? BigeyePercentage { get; set; }

        /// <summary>
        /// Gets or sets the number of tons of bigeye in the total target catch
        /// </summary>
        public virtual decimal? TonsOfBigeyeObserved { get; set; }

        public virtual int? LargeYellowfinPercentage { get; set; }

        public virtual int? LargeBigeyePercentage { get; set; }

        public virtual int? LargeYellowfinCount { get; set; }

        public virtual int? LargeBigeyeCount { get; set; }

        public virtual bool? ContainsLargeTuna { get; set; }

        public virtual int? LargeTunaPercentage { get; set; }

        public virtual decimal? TonsOfYellowfinAndBigeyeObserved { get; set; }

        public virtual bool? TotalTunaAnswer { get; set; }

        public virtual int? PercentageOfTuna { get; set; }

        public virtual decimal? TonsOfTunaObserved2 { get; set; }

        public virtual string LargeSpecies { get; set; }

        public virtual int? LargeSpeciesPercentage { get; set; }

        public virtual int? LargeSpeciesCount { get; set; }

        public virtual bool? ContainsLargeYellowfin { get; set; }

        public virtual bool? ContainsLargeBigeye { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TotalCatch")]
        public virtual decimal? TotalCatch { get; set; }

        public virtual int? RecoveredTagCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public virtual string Comments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
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

        public virtual IList<LengthSamplingHeader> SamplingHeaders { get; protected internal set; }

        public virtual IList<PurseSeineSetCatch> CatchList { get; protected internal set; }

        public virtual void AddSetCatch(PurseSeineSetCatch setcatch)
        {
            setcatch.FishingSet = this;
            this.CatchList.Add(setcatch);
        }

        public virtual void AddSampleHeader(LengthSamplingHeader header)
        {
            header.Set = this;
            this.SamplingHeaders.Add(header);
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
