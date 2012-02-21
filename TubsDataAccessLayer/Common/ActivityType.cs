// -----------------------------------------------------------------------
// <copyright file="ActivityType.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Common
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
    using System.ComponentModel;

    /// <summary>
    /// These values represent the reference_id values for source
    /// 'ACTIV'.  Values are hard-coded to simplify use with NHibernate.
    /// If this solution isn't flexible enough, investigate this solution:
    /// http://openlandscape.net/2011/04/16/hey-nhibernate-dont-mess-with-my-enums/
    /// </summary>
    public enum ActivityType
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Fishing
        /// </summary>
        [Description("Fishing")]
        Fishing = 1,

        /// <summary>
        /// Searching
        /// </summary>
        [Description("Searching")]
        Searching = 2,

        /// <summary>
        /// Transit
        /// </summary>
        [Description("Transit")]
        Transit = 3,

        /// <summary>
        /// No fishing - Breakdown
        /// </summary>
        [Description("No fishing - Breakdown")]
        NoFishingBreakdown = 4,

        /// <summary>
        /// No fishing - Bad weather
        /// </summary>
        [Description("No fishing - Bad weather")]
        NoFishingBadWeather = 5,

        /// <summary>
        /// In port - please specify
        /// </summary>
        [Description("In port - please specify")]
        InPort = 6,

        /// <summary>
        /// Net cleaning set
        /// </summary>
        [Description("Net cleaning set")]
        NetCleaningSet = 7,

        /// <summary>
        /// Investigate free school
        /// </summary>
        [Description("Investigate free school")]
        InvestigateFreeSchool = 8,

        /// <summary>
        /// Investigate floating object / log
        /// </summary>
        [Description("Investigate floating object / log")]
        InvestigateFloatingObject = 9,

        /// <summary>
        /// Deploy - raft, FAD or payao (10D)
        /// </summary>
        [Description("Deploy - raft, FAD or payao (10D)")]
        DeployFad = 10,

        /// <summary>
        /// Retrieve - raft, FAD or payao (10R)
        /// </summary>
        [Description("Retrieve - raft, FAD or payao (10R)")]
        RetrieveFad = 11,

        /// <summary>
        /// No fishing - Drifting at days end
        /// </summary>
        [Description("No fishing - Drifting at days end")]
        NoFishingDriftingAtDaysEnd = 12,

        /// <summary>
        /// No fishing - Drifting with floating object
        /// </summary>
        [Description("No fishing - Drifting with floating object")]
        NoFishingDriftingWithFloatingObject = 13,

        /// <summary>
        /// No fishing - Other reason (specify)
        /// </summary>
        [Description("No fishing - Other reason (specify)")]
        NoFishingOther = 14,

        /// <summary>
        /// Drifting - With fish aggregating lights
        /// </summary>
        [Description("Drifting - With fish aggregating lights")]
        DriftingWithLights = 15,

        /// <summary>
        /// Retrieve radio buoy (15R)
        /// </summary>
        [Description("Retrieve radio buoy (15R)")]
        RetrieveRadioBuoy = 16,

        /// <summary>
        /// Deploy radio buoy (15D)
        /// </summary>
        [Description("Deploy radio buoy (15D)")]
        DeployRadioBuoy = 17,

        /// <summary>
        /// Transshipping or bunkering
        /// </summary>
        [Description("Transshipping or bunkering")]
        TransshippingOrBunkering = 18,

        /// <summary>
        /// Helicopter takes off to search (H1)
        /// </summary>
        [Description("Helicopter takes off to search (H1)")]
        HelicopterTakesOffToSearch = 19,

        /// <summary>
        /// Helicopter returns from search (H2)
        /// </summary>
        [Description("Helicopter returns from search (H2)")]
        HelicopterReturnsFromSearch = 20,

        /// <summary>
        /// Bait Fishing
        /// </summary>
        [Description("Bait Fishing")]
        BaitFishing = 91,

        /// <summary>
        /// Anchored in bait grounds
        /// </summary>
        [Description("Anchored in bait grounds")]
        AnchoredInBaitGrounds = 92,

        /// <summary>
        /// Transshipping at sea
        /// </summary>
        [Description("Transshipping at sea")]
        TransshippingAtSea = 118
    }
}
