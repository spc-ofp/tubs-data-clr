// -----------------------------------------------------------------------
// <copyright file="VesselTypeCode.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;

    /// <summary>
    /// Represents the values present in the table ref.vessel_types.
    /// These values are stored in ref_vessel in the column 'vty_code'
    /// </summary>
    public enum VesselTypeCode
    {
        /// <summary>
        /// Unknown or no value provided
        /// </summary>
        [Description("Unknown")]
        None,

        /// <summary>
        /// Bunker
        /// </summary>
        [Description("Bunker")]
        BK,

        /// <summary>
        /// General Fishing
        /// </summary>
        [Description("General Fishing")]
        GF,

        /// <summary>
        /// Longliner
        /// </summary>
        [Description("Longliner")]
        LL,

        /// <summary>
        /// Mothership
        /// </summary>
        [Description("Mothership")]
        MS,

        /// <summary>
        /// Pole and Line
        /// </summary>
        [Description("Pole and Line")]
        PL,

        /// <summary>
        /// Single Purse Seiner
        /// </summary>
        [Description("Single Purse Seiner")]
        PS,

        /// <summary>
        /// Carrier/Reefer
        /// </summary>
        [Description("Carrier/Reefer")]
        RC
    }
}
