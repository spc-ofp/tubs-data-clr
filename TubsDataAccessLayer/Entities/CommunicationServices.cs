// -----------------------------------------------------------------------
// <copyright file="CommunicationServices.cs" company="Secretariat of the Pacific Community">
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
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// CommunicationServices captures the high-level communications and electronics details
    /// present on a vessel during a trip.
    /// </summary>
    public class CommunicationServices
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual bool? HasSatellitePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string SatellitePhoneNumber { get; set; }

        public virtual bool? HasMobilePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string MobilePhoneNumber { get; set; }

        public virtual bool? HasFax { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string FaxNumber { get; set; }

        public virtual bool? HasEmail { get; set; }

        [DataType(DataType.EmailAddress)]
        public virtual string EmailAddress { get; set; }

        public virtual bool? HasWeatherFax { get; set; }

        public virtual bool? HasSatelliteMonitor { get; set; }

        public virtual bool? HasOther { get; set; }

        public virtual bool? HasPhytoplanktonService { get; set; }

        [DataType(DataType.Url)]
        public virtual string PhytoplanktonUrl { get; set; }

        public virtual bool? HasSeaSurfaceTemperatureService { get; set; }

        [DataType(DataType.Url)]
        public virtual string SeaSurfaceTemperatureUrl { get; set; }

        public virtual bool? HasSeaHeightService { get; set; }

        [DataType(DataType.Url)]
        public virtual string SeaHeightServiceUrl { get; set; }

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
    }
}
