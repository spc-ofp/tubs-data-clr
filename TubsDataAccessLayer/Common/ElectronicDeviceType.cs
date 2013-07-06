// -----------------------------------------------------------------------
// <copyright file="ElectronicDeviceType.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
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
    /// Enumeration of the common electronic devices found on
    /// fishing vessels.
    /// It is backed by the table [obsv].[ref_electronic_devices].
    /// This is not intended to be an exhaustive list of all possible
    /// electronic devices.
    /// </summary>
    public enum ElectronicDeviceType
    {
        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        Other = 115,       
        
        /// <summary>
        /// GPS
        /// </summary>
        [Description("GPS")]
        Gps = 21,

        /// <summary>
        /// Depth Sounder
        /// </summary>
        [Description("Depth Sounder")]
        DepthSounder = 14,

        /// <summary>
        /// Track Plotter
        /// </summary>
        [Description("Track Plotter")]
        TrackPlotter = 51,

        /// <summary>
        /// SST Gauge
        /// </summary>
        [Description("SST Gauge")]
        SstGauge = 47,

        /// <summary>
        /// Sonar
        /// </summary>
        [Description("Sonar")]
        Sonar = 48,

        /// <summary>
        /// GPS Buoys
        /// </summary>
        [Description("GPS Buoys")]
        GpsBuoys = 89,

        /// <summary>
        /// Doppler Current Meter
        /// </summary>
        [Description("Doppler Current Meter")]
        DopplerCurrentMeter = 17,

        /// <summary>
        /// VMS
        /// </summary>
        [Description("VMS")]
        Vms = 53,

        /// <summary>
        /// Bird Radar
        /// </summary>
        [Description("Bird Radar")]
        BirdRadar = 5,

        /// <summary>
        /// Echo Sounding Buoy
        /// </summary>
        [Description("Echo Sounding Buoy")]
        EchoSoundingBuoy = 99,

        /// <summary>
        /// Net Depth Instrumentation
        /// </summary>
        [Description("Net Depth Instrumentation")]
        NetDepthInstrumentation = 127,

        /// <summary>
        /// Radio Beacon Direction Finder
        /// </summary>
        [Description("Radio Beacon Direction Finder")]
        RadioBeaconDirectionFinder = 38,

        /// <summary>
        /// Bathythermograph
        /// </summary>
        [Description("Bathythermograph")]
        Bathythermograph = 3

    }
}
