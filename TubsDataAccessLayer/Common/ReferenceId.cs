// -----------------------------------------------------------------------
// <copyright file="ReferenceId.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
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
        [Description("Unknown")]
        None = 0,
        [Description("Fishing")]
        Fishing = 1,
        [Description("Searching")]
        Searching = 2,
        [Description("Transit")]
        Transit = 3,
        [Description("No fishing - Breakdown")]
        NoFishingBreakdown = 4,
        [Description("No fishing - Bad weather")]
        NoFishingBadWeather = 5,
        [Description("In port - please specify")]
        InPort = 6,
        [Description("Net cleaning set")]
        NetCleaningSet = 7,
        [Description("Investigate free school")]
        InvestigateFreeSchool = 8,
        [Description("Investigate floating object / log")]
        InvestigateFloatingObject = 9,
        [Description("Deploy - raft, FAD or payao (10D)")]
        DeployFad = 10,
        [Description("Retrieve - raft, FAD or payao (10R)")]
        RetrieveFad = 11,
        [Description("No fishing - Drifting at days end")]
        NoFishingDriftingAtDaysEnd = 12,
        [Description("No fishing - Drifting with floating object")]
        NoFishingDriftingWithFloatingObject = 13,
        [Description("No fishing - Other reason (specify)")]
        NoFishingOther = 14,
        [Description("Drifting - With fish aggregating lights")]
        DriftingWithLights = 15,
        [Description("Retrieve radio buoy (15R)")]
        RetrieveRadioBuoy = 16,
        [Description("Deploy radio buoy (15D)")]
        DeployRadioBuoy = 17,
        [Description("Transshipping or bunkering")]
        TransshippingOrBunkering = 18,
        [Description("Helicopter takes off to search (H1)")]
        HelicopterTakesOffToSearch = 19,
        [Description("Helicopter returns from search (H2)")]
        HelicopterReturnsFromSearch = 20,
        [Description("Bait Fishing")]
        BaitFishing = 91,
        [Description("Anchored in bait grounds")]
        AnchoredInBaitGrounds = 92,
        [Description("Transshipping at sea")]
        TransshippingAtSea = 118
    }

    /// <summary>
    /// These values represent the reference_id values for source 'SCHAS'
    /// </summary>
    public enum SchoolAssociation
    {
        [Description("Unknown")]
        None = 0,
        [Description("Unassociated")]
        Unassociated = 21,
        [Description("Feeding on baitfish")]
        FeedingOnBaitfish = 22,
        [Description("Drifting log, debris, or dead animal")]
        DriftingLog = 23,
        [Description("Drifting raft, FAD or payao")]
        DriftingRaft = 24,
        [Description("Anchored raft, FAD or payao")]
        AnchoredRaft = 25,
        [Description("Live whale")]
        LiveWhale = 26,
        [Description("Live whale shark")]
        LiveWhaleShark = 27,
        [Description("Other (please specify)")]
        Other = 28,
        [Description("No tuna associated")]
        NoTuna = 29,
        [Description("Whale, Whale Shark, or Porpoise (old forms)")]
        WhaleWhaleSharkPorpoise = 119
    }

    /// <summary>
    /// These values represent the reference_id values for source 'DETON'
    /// </summary>
    public enum DetectionMethod
    {
        [Description("Unknown")]
        None = 0,
        [Description("Seen from vessel")]
        SeenFromVessel = 30,
        [Description("Seen from helicopter")]
        SeenFromHelicopter = 31,
        [Description("Marked with beacon")]
        MarkedWithBeacon = 32,
        [Description("Bird radar")]
        BirdRadar = 33,
        [Description("Sonar/depth sounder")]
        Sonar = 34,
        [Description("Info. from other vessel")]
        InfoFromOtherVessel = 35,
        [Description("Anchored FAD/payao (recorded)")]
        Anchored = 36,
    }

    public enum SamplingProtocol
    {
        [Description("Unknown")]
        None = 0,
        [Description("Random (normal) sample")]
        Normal = 88,
        [Description("Other")]
        Other = 89,
        [Description("Small fish sample only")]
        SmallFish = 90,
    }

    public enum LengthCode
    {
        [Description("Anal fin length")]
        AN,
        [Description("Bill to fork in tail")]
        BL,
        [Description("Curved Carapace Length")]
        CC,
        [Description("Cleithrum to anterior base caudal keel")]
        CK,
        [Description("carapace length (turtles)")]
        CL,
        [Description("Carapace width")]
        CW,
        [Description("Cleithrum to caudal fork")]
        CX,
        [Description("Posterior eye orbital to caudal fork")]
        EO,
        [Description("Posterior eye orbital to vent")]
        EV,
        [Description("1st dorsal to fork in tail")]
        FF,
        [Description("Weight of all fins (sharks)")]
        FN,
        [Description("1st dorsal to 2nd dorsal")]
        FS,
        [Description("Fillets weight")]
        FW,
        [Description("Gilled, gutted, headed, flaps removed")]
        GF,
        [Description("Gilled and gutted weight")]
        GG,
        [Description("Gutted and headed weight")]
        GH,
        [Description("Girth")]
        GI,
        [Description("Gutted only (gills left in)")]
        GO,
        [Description("Gilled, gutted and tailed")]
        GT,
        [Description("Gutted, headed and tailed")]
        GX,
        [Description("lower jaw to fork in tail")]
        LF,
        [Description("not measured")]
        NM,
        [Description("Observer's Estimate")]
        OW,
        [Description("pectoral fin to fork in tail")]
        PF,
        [Description("Pectoral fin to 2nd dorsal")]
        PS,
        [Description("Straight Carapace Length")]
        SC,
        [Description("Tip of snout to end of caudal peduncle")]
        SL,
        [Description("Body Thickness (Width)")]
        TH,
        [Description("tip of snout to end of tail")]
        TL,
        [Description("total width (tip of wings - rays)")]
        TW,
        [Description("upper jaw to fork in tail")]
        UF,
        [Description("Upper jaw to 2nd dorsal fin")]
        US,
        [Description("Whole weight")]
        WW
    }
}