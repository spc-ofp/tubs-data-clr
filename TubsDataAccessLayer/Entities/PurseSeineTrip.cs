// -----------------------------------------------------------------------
// <copyright file="PurseSeineTrip.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;

    /// <summary>
    /// Purse Seine trip entity.
    /// </summary>
    public class PurseSeineTrip : Trip
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public PurseSeineTrip()
            : base()
        {
            this.SeaDays = new List<PurseSeineSeaDay>(30);
            this.Crew = new List<PurseSeineCrew>(16);
            this.WellContent = new List<PurseSeineWellContent>(16);
            this.WellReconciliations = new List<PurseSeineWellReconciliation>(24);
        }

        /// <summary>
        /// Get Purse Seine gear.
        /// </summary>
        /// <returns>Base Gear class</returns>
        public override Gear GetGear()
        {
            return this.Gear;
        }
        
        /// <summary>
        /// Gets or sets Gear entity.
        /// </summary>
        public virtual PurseSeineGear Gear { get; set; }

        /// <summary>
        /// Gets or sets VesselAttributes entity.
        /// </summary>
        public virtual PurseSeineVesselAttributes VesselAttributes { get; set; }

        /// <summary>
        /// Gets or sets list of SeaDays.
        /// </summary>
        public virtual IList<PurseSeineSeaDay> SeaDays { get; protected internal set; }

        /// <summary>
        /// Gets or sets list of Crew.
        /// </summary>
        public virtual IList<PurseSeineCrew> Crew { get; protected internal set; }

        /// <summary>
        /// Gets or sets well content.
        /// </summary>
        public virtual IList<PurseSeineWellContent> WellContent { get; protected internal set; }

        /// <summary>
        /// Gets or sets list of internal well transfers
        /// </summary>
        public virtual IList<PurseSeineWellReconciliation> WellReconciliations { get; protected internal set; }

        /// <summary>
        /// Gets a collection of all sets for the trip.
        /// This is a fairly common request and so should be implemented here in trip.
        /// </summary>
        public virtual IEnumerable<PurseSeineSet> FishingSets
        {
            get
            {
                return (
                    from day in this.SeaDays
                    from act in day.Activities
                    where act.ActivityType.HasValue && Common.ActivityType.Fishing == act.ActivityType && null != act.FishingSet
                    select act.FishingSet
                );
            }
        }

        /// <summary>
        /// Gets a collection of all fish aggregating devices (FADs).
        /// Less common than sets, but may be more useful in the future with
        /// building emphasis on FADs, FAD closure periods, etc.
        /// </summary>
        public virtual IEnumerable<Gen5Object> FishAggregatingDevices
        {
            get
            {
                return (
                    from d in this.SeaDays
                    from a in d.Activities
                    where a.Fad != null
                    select a.Fad
                );
            }
        }

        /// <summary>
        /// Sum of all catch with an observer weight, grouped by species code.
        /// If the observer recorded a count without a weight (which is perfectly acceptable)
        /// those species will not be included in the catch
        /// </summary>
        /// <remarks>
        /// Ideally, I'd like to call this 'Catch'.  C# allows that, as only 'catch' is a reserved word.
        /// That said, using a reserved word but for case makes for confusing code.
        /// </remarks>
        public virtual IDictionary<string, decimal> TotalTripCatch
        {
            get
            {
                // With some help from Stack Overflow, do this as a single C# statement
                // http://stackoverflow.com/questions/3414080/using-groupby-count-and-sum-in-linq-lambda-expressions
                // http://stackoverflow.com/questions/627867/linq-query-to-return-a-dictionarystring-string
                
                //In order to avoid strange results 
                // (e.g. fish were counted but no weight was estimated, resulting in zero weight)
                // if no weight was estimated, the PurseSeineSetCatch object is skipped 
                return this.FishingSets
                    .SelectMany(fs => fs.CatchList) // Merge all CatchList children into a single list
                    .Where(sc => sc.MetricTonsObserved.HasValue)
                    .GroupBy(l => l.SpeciesCode)
                    .ToDictionary(
                        l => l.Key, 
                        l => l.Sum(w => w.MetricTonsObserved) ?? 0M
                    );
            }
        }

        /// <summary>
        /// Count of the days spent fishing and searching.  One minute of searching in one day
        /// counts a one full day of effort in this implementation.
        /// </summary>
        public virtual int VesselDays
        {
            get
            {
                return (
                    from day in this.SeaDays
                    from act in day.Activities
                    where act.ActivityType.HasValue && (
                        Common.ActivityType.Fishing == act.ActivityType.Value ||
                        Common.ActivityType.Searching == act.ActivityType.Value)
                    select day.Id
                ).Distinct().Count();
            }
        }

        /// <summary>
        /// Catch per unit effort (CPUE)
        /// </summary>
        public virtual decimal Cpue
        {
            get
            {
                if (!this.TotalTripCatch.Any())
                    return 0M;

                return this.TotalTripCatch.Values.Sum() / (decimal)this.FishingSets.Count();
            }
        }

        /// <summary>
        /// Add a sea day to a trip.
        /// Using this method respects the parent-child linkage.
        /// </summary>
        /// <param name="seaday">Sea day being added</param>
        public virtual void AddSeaDay(PurseSeineSeaDay seaday)
        {
            if (null == seaday)
                return;
            
            seaday.Trip = this;
            this.SeaDays.Add(seaday);
        }

        /// <summary>
        /// Add a crew member to the trip.
        /// Using this method respects the parent-child linkage.
        /// </summary>
        /// <param name="crew">Crew member being added</param>
        public virtual void AddCrew(PurseSeineCrew crew)
        {
            if (null == crew)
                return;
            
            crew.Trip = this;
            this.Crew.Add(crew);
        }

        /// <summary>
        /// Add well contents to the trip.
        /// Using this method respects the parent-child linkage.
        /// </summary>
        /// <param name="wellcontent">Well content being added</param>
        public virtual void AddWellContent(PurseSeineWellContent wellcontent)
        {
            if (null == wellcontent)
                return;
            
            wellcontent.Trip = this;
            this.WellContent.Add(wellcontent);
        }

        /// <summary>
        /// Add a well transfer to the trip.
        /// Using this method respects the parent-child linkage.
        /// </summary>
        /// <param name="reconciliation">Well transfer being added</param>
        public virtual void AddWellReconciliation(PurseSeineWellReconciliation reconciliation)
        {
            if (null == reconciliation)
                return;
            
            reconciliation.Trip = this;
            this.WellReconciliations.Add(reconciliation);
        }
    }
}
