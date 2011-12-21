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

    /// <summary>
    /// These values represent the reference_id values for source 'SCHAS'
    /// </summary>
    public enum SchoolAssociation
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Unassociated
        /// </summary>
        [Description("Unassociated")]
        Unassociated = 21,

        /// <summary>
        /// Feeding on baitfish
        /// </summary>
        [Description("Feeding on baitfish")]
        FeedingOnBaitfish = 22,

        /// <summary>
        /// Drifting log, debris, or dead animal
        /// </summary>
        [Description("Drifting log, debris, or dead animal")]
        DriftingLog = 23,

        /// <summary>
        /// Drifting raft, FAD or payao
        /// </summary>
        [Description("Drifting raft, FAD or payao")]
        DriftingRaft = 24,

        /// <summary>
        /// Anchored raft, FAD or payao
        /// </summary>
        [Description("Anchored raft, FAD or payao")]
        AnchoredRaft = 25,

        /// <summary>
        /// Live whale
        /// </summary>
        [Description("Live whale")]
        LiveWhale = 26,

        /// <summary>
        /// Live whale shark
        /// </summary>
        [Description("Live whale shark")]
        LiveWhaleShark = 27,

        /// <summary>
        /// Other (please specify)
        /// </summary>
        [Description("Other (please specify)")]
        Other = 28,

        /// <summary>
        /// No tuna associated
        /// </summary>
        [Description("No tuna associated")]
        NoTuna = 29,

        /// <summary>
        /// Whale, Whale Shark, or Porpoise (old forms)
        /// </summary>
        [Description("Whale, Whale Shark, or Porpoise (old forms)")]
        WhaleWhaleSharkPorpoise = 119
    }

    /// <summary>
    /// These values represent the reference_id values for source 'DETON'
    /// </summary>
    public enum DetectionMethod
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Seen from vessel
        /// </summary>
        [Description("Seen from vessel")]
        SeenFromVessel = 30,

        /// <summary>
        /// Seen from helicopter
        /// </summary>
        [Description("Seen from helicopter")]
        SeenFromHelicopter = 31,

        /// <summary>
        /// Marked with beacon
        /// </summary>
        [Description("Marked with beacon")]
        MarkedWithBeacon = 32,

        /// <summary>
        /// Bird radar
        /// </summary>
        [Description("Bird radar")]
        BirdRadar = 33,

        /// <summary>
        /// Sonar/depth sounder
        /// </summary>
        [Description("Sonar/depth sounder")]
        Sonar = 34,

        /// <summary>
        /// Info. from other vessel
        /// </summary>
        [Description("Info. from other vessel")]
        InfoFromOtherVessel = 35,

        /// <summary>
        /// Anchored FAD/payao (recorded)
        /// </summary>
        [Description("Anchored FAD/payao (recorded)")]
        Anchored = 36,
    }

    /// <summary>
    /// These values represent the reference_id values for source 'PROTO'
    /// </summary>
    public enum SamplingProtocol
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Random (normal) sample
        /// </summary>
        [Description("Random (normal) sample")]
        Normal = 88,

        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        Other = 89,

        /// <summary>
        /// Small fish sample only
        /// </summary>
        [Description("Small fish sample only")]
        SmallFish = 90,
    }

    /// <summary>
    /// These values represent codes from [obsv].[ref_len]
    /// </summary>
    public enum LengthCode
    {
        /// <summary>
        /// Anal fin length
        /// </summary>
        [Description("Anal fin length")]
        AN,

        /// <summary>
        /// Bill to fork in tail
        /// </summary>
        [Description("Bill to fork in tail")]
        BL,

        /// <summary>
        /// Curved Carapace Length
        /// </summary>
        [Description("Curved Carapace Length")]
        CC,

        /// <summary>
        /// Cleithrum to anterior base caudal keel
        /// </summary>
        [Description("Cleithrum to anterior base caudal keel")]
        CK,

        /// <summary>
        /// Carapace length (turtles)
        /// </summary>
        [Description("Carapace length (turtles)")]
        CL,

        /// <summary>
        /// Carapace width
        /// </summary>
        [Description("Carapace width")]
        CW,

        /// <summary>
        /// Cleithrum to caudal fork
        /// </summary>
        [Description("Cleithrum to caudal fork")]
        CX,

        /// <summary>
        /// Posterior eye orbital to caudal fork
        /// </summary>
        [Description("Posterior eye orbital to caudal fork")]
        EO,

        /// <summary>
        /// Posterior eye orbital to vent
        /// </summary>
        [Description("Posterior eye orbital to vent")]
        EV,

        /// <summary>
        /// 1st dorsal to fork in tail
        /// </summary>
        [Description("1st dorsal to fork in tail")]
        FF,

        /// <summary>
        /// Weight of all fins (sharks)
        /// </summary>
        [Description("Weight of all fins (sharks)")]
        FN,

        /// <summary>
        /// 1st dorsal to 2nd dorsal
        /// </summary>
        [Description("1st dorsal to 2nd dorsal")]
        FS,

        /// <summary>
        /// Fillets weight
        /// </summary>
        [Description("Fillets weight")]
        FW,

        /// <summary>
        /// Gilled, gutted, headed, flaps removed
        /// </summary>
        [Description("Gilled, gutted, headed, flaps removed")]
        GF,

        /// <summary>
        /// Gilled and gutted weight
        /// </summary>
        [Description("Gilled and gutted weight")]
        GG,

        /// <summary>
        /// Gutted and headed weight
        /// </summary>
        [Description("Gutted and headed weight")]
        GH,

        /// <summary>
        /// Girth
        /// </summary>
        [Description("Girth")]
        GI,

        /// <summary>
        /// Gutted only (gills left in)
        /// </summary>
        [Description("Gutted only (gills left in)")]
        GO,

        /// <summary>
        /// Gilled, gutted and tailed
        /// </summary>
        [Description("Gilled, gutted and tailed")]
        GT,

        /// <summary>
        /// Gutted, headed and tailed
        /// </summary>
        [Description("Gutted, headed and tailed")]
        GX,

        /// <summary>
        /// Lower jaw to fork in tail
        /// </summary>
        [Description("Lower jaw to fork in tail")]
        LF,

        /// <summary>
        /// Not measured
        /// </summary>
        [Description("Not measured")]
        NM,

        /// <summary>
        /// Observer's Estimate
        /// </summary>
        [Description("Observer's Estimate")]
        OW,

        /// <summary>
        /// Pectoral fin to fork in tail
        /// </summary>
        [Description("Pectoral fin to fork in tail")]
        PF,

        /// <summary>
        /// Pectoral fin to 2nd dorsal
        /// </summary>
        [Description("Pectoral fin to 2nd dorsal")]
        PS,

        /// <summary>
        /// Straight Carapace Length
        /// </summary>
        [Description("Straight Carapace Length")]
        SC,

        /// <summary>
        /// Tip of snout to end of caudal peduncle
        /// </summary>
        [Description("Tip of snout to end of caudal peduncle")]
        SL,

        /// <summary>
        /// Body Thickness (Width)
        /// </summary>
        [Description("Body Thickness (Width)")]
        TH,

        /// <summary>
        /// Tip of snout to end of tail
        /// </summary>
        [Description("Tip of snout to end of tail")]
        TL,

        /// <summary>
        /// Total width (tip of wings - rays)
        /// </summary>
        [Description("Total width (tip of wings - rays)")]
        TW,

        /// <summary>
        /// Upper jaw to fork in tail
        /// </summary>
        [Description("Upper jaw to fork in tail")]
        UF,

        /// <summary>
        /// Upper jaw to 2nd dorsal fin
        /// </summary>
        [Description("Upper jaw to 2nd dorsal fin")]
        US,

        /// <summary>
        /// Whole weight
        /// </summary>
        [Description("Whole weight")]
        WW
    }

    /// <summary>
    /// These values represent codes from [obsv].[ref_sea]
    /// </summary>
    public enum SeaCode
    {
        /// <summary>
        /// Calm
        /// </summary>
        [Description("Calm")]
        C,

        /// <summary>
        /// Slight
        /// </summary>
        [Description("Slight")]
        S,

        /// <summary>
        /// Moderate
        /// </summary>
        [Description("Moderate")]
        M,

        /// <summary>
        /// Rough
        /// </summary>
        [Description("Rough")]
        R,
      
        /// <summary>
        /// Very Rough
        /// </summary>
        [Description("Very Rough")]
        V
    }

    /// <summary>
    /// These values represent the reference_id values for source 'POTYP'
    /// </summary>
    public enum PollutionType
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Waste dumped overboard
        /// </summary>
        [Description("Waste dumped overboard")]
        DumpedOverboard = 71,

        /// <summary>
        /// Oil spillages and leakages
        /// </summary>
        [Description("Oil spillages and leakages")]
        SpillageOrLeakage = 72
    }

    /// <summary>
    /// These values represent the reference_id values for source 'POLMT'
    /// </summary>
    public enum PollutionMaterial
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Plastics
        /// </summary>
        [Description("Plastics")]
        Plastics = 60,

        /// <summary>
        /// Metals
        /// </summary>
        [Description("Metals")]
        Metals = 61,

        /// <summary>
        /// Waste Oils
        /// </summary>
        [Description("Waste Oils")]
        WasteOils = 62,

        /// <summary>
        /// Chemicals
        /// </summary>
        [Description("Chemicals")]
        Chemicals = 63,

        /// <summary>
        /// Old Fishing Gear
        /// </summary>
        [Description("Old Fishing Gear")]
        OldFishingGear = 64,

        /// <summary>
        /// General Garbage
        /// </summary>
        [Description("General Garbage")]
        GeneralGarbage = 65,
    }

    /// <summary>
    /// These values represent the reference_id values for source 'VATYP'
    /// </summary>
    public enum VesselType
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Single Purse Seine
        /// </summary>
        [Description("Single Purse Seine")]
        SinglePurseSeine = 47,

        /// <summary>
        /// Longline
        /// </summary>
        [Description("Longline")]
        Longline = 48,

        /// <summary>
        /// Pole and line
        /// </summary>
        [Description("Pole and line")]
        PoleAndLine = 49,

        /// <summary>
        /// Mothership
        /// </summary>
        [Description("Mothership")]
        Mothership = 50,

        /// <summary>
        /// Troll
        /// </summary>
        [Description("Troll")]
        Troll = 51,

        /// <summary>
        /// Net Boat
        /// </summary>
        [Description("Net Boat")]
        NetBoat = 52,

        /// <summary>
        /// Bunker
        /// </summary>
        [Description("Bunker")]
        Bunker = 53,

        /// <summary>
        /// Search, Anchor or light boat
        /// </summary>
        [Description("Search, Anchor or light boat")]
        SearchAnchorOrLightBoat = 54,

        /// <summary>
        /// Fish Carrier
        /// </summary>
        [Description("Fish Carrier")]
        FishCarrier = 55,

        /// <summary>
        /// Trawler
        /// </summary>
        [Description("Trawler")]
        Trawler = 56,

        /// <summary>
        /// Light Aircraft
        /// </summary>
        [Description("Light Aircraft")]
        LightAircraft = 57,

        /// <summary>
        /// Helicopter
        /// </summary>
        [Description("Helicopter")]
        Helicopter = 58,

        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        Other = 59
    }

    /// <summary>
    /// These values represent codes from [obsv].[ref_action]
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Aground
        /// </summary>
        [Description("Aground")]
        AG,

        /// <summary>
        /// Bunkering (transfer of fuel), vessel observer is on is giving
        /// </summary>
        [Description("Bunkering (transfer of fuel), vessel observer is on is giving")]
        BG,
	
        /// <summary>
        /// Bunkering (transfer of fuel), vessel observer is on is receiving
        /// </summary>
        [Description("Bunkering (transfer of fuel), vessel observer is on is receiving")]
        BR,
	
        /// <summary>
        /// Dumping of fish
        /// </summary>
        [Description("Dumping of fish")]
        DF,
	
        /// <summary>
        /// Fishing
        /// </summary>
        [Description("Fishing")]
        FI,
	
        /// <summary>
        /// From set
        /// </summary>
        [Description("From set")]
        FS,
	
        /// <summary>
        /// Not fishing
        /// </summary>
        [Description("Not fishing")]
        NF,	

        /// <summary>
        /// Other, vessel observer is on is giving
        /// </summary>
        [Description("Other, vessel observer is on is giving")]
        OG,
	
        /// <summary>
        /// Other, vessel observer is on is receiving
        /// </summary>
        [Description("Other, vessel observer is on is receiving")]
        OR,
	
        /// <summary>
        /// Possibly fishing
        /// </summary>
        [Description("Possibly fishing")]
        PF,
	
        /// <summary>
        /// Set sharing, vessel observer is on is giving
        /// </summary>
        [Description("Set sharing, vessel observer is on is giving")]
        SG,
	
        /// <summary>
        /// Set sharing, vessel observer is on is receiving
        /// </summary>
        [Description("Set sharing, vessel observer is on is receiving")]
        SR,
	
        /// <summary>
        /// Transfering fish between vessels, vessel observer is on is giving
        /// </summary>
        [Description("Transfering fish between vessels, vessel observer is on is giving")]
        TG,
	
        /// <summary>
        /// Transfering fish between vessels, vessel observer is on is receiving
        /// </summary>
        [Description("Transfering fish between vessels, vessel observer is on is receiving")]
        TR,
	
        /// <summary>
        /// Unloaded at cannery or cool store
        /// </summary>
        [Description("Unloaded at cannery or cool store")]
        UL,
	
        /// <summary>
        /// Transferred between wells
        /// </summary>
        [Description("Transferred between wells")]
        WT
    }

    /// <summary>
    /// These values represent the reference_id values for source 'VSJOB'
    /// </summary>
    public enum JobType
    {
        /// <summary>
        /// No value provided or unknown
        /// </summary>
        [Description("Unknown")]
        None = 0,

        /// <summary>
        /// Captain
        /// </summary>
        [Description("Captain")]
        Captain = 37,

        /// <summary>
        /// Navigator/Master
        /// </summary>
        [Description("Navigator/Master")]
        NavigatorOrMaster = 38,

        /// <summary>
        /// Mate
        /// </summary>
        [Description("Mate")]
        Mate = 39,

        /// <summary>
        /// Chief Engineer
        /// </summary>
        [Description("Chief Engineer")]
        ChiefEngineer = 40,

        /// <summary>
        /// Assistant Engineer
        /// </summary>
        [Description("Assistant Engineer")]
        AssistantEngineer = 41,

        /// <summary>
        /// Deck Boss
        /// </summary>
        [Description("Deck Boss")]
        DeckBoss = 42,

        /// <summary>
        /// Cook
        /// </summary>
        [Description("Cook")]
        Cook = 43,

        /// <summary>
        /// Helicopter Pilot
        /// </summary>
        [Description("Helicopter Pilot")]
        HelicopterPilot = 44,

        /// <summary>
        /// Skiff Man
        /// </summary>
        [Description("Skiff Man")]
        SkiffMan = 45,

        /// <summary>
        /// Winch Man
        /// </summary>
        [Description("Winch Man")]
        WinchMan = 46,

        /// <summary>
        /// Helicopter Mechanic
        /// </summary>
        [Description("Helicopter Mechanic")]
        HelicopterMechanic = 105,

        /// <summary>
        /// Generic crew member
        /// </summary>
        [Description("Crew")]
        Crew = 107
    }

    /// <summary>
    /// These values represent codes from [obsv].[ref_usage]
    /// </summary>
    public enum UsageCode
    {
        /// <summary>
        /// Used all the time in fishing
        /// </summary>
        [Description("Used all the time in fishing")]
        ALL,

        /// <summary>
        /// Used only in transit
        /// </summary>
        [Description("Used only in transit")]
        TRA,

        /// <summary>
        /// Used often in fishing
        /// </summary>
        [Description("Used often in fishing")]
        OIF,

        /// <summary>
        /// Used sometimes in fishing
        /// </summary>
        [Description("Used sometimes in fishing")]
        SIF,

        /// <summary>
        /// Rarely used
        /// </summary>
        [Description("Rarely used")]
        RAR,

        /// <summary>
        /// Broken now but used normally
        /// </summary>
        [Description("Broken now but used normally")]
        BRO,

        /// <summary>
        /// No longer ever used
        /// </summary>
        [Description("No longer ever used")]
        NOL,

        /// <summary>
        /// Not applicable / Not filled
        /// </summary>
        [Description("Not applicable / Not filled")]
        NA
    }
}