﻿// -----------------------------------------------------------------------
// <copyright file="ElectronicDevice.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ElectronicDevice : IAuditable, IEntity
    {
        /// <summary>
        /// Entity primary key.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Reference to trip.
        /// </summary>
        public virtual Trip Trip { get; set; }

        /// <summary>
        /// Major device type description.
        /// </summary>
        public virtual ElectronicDeviceType DeviceType { get; set; }

        /// <summary>
        /// Optional description for ElectronicDeviceType.Other
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// System description for VMS systems.
        /// </summary>
        public virtual string SystemDescription { get; set; }

        /// <summary>
        /// Are VMS seals intact?
        /// </summary>
        public virtual bool? SealsIntact { get; set; }

        public virtual bool? IsInstalled { get; set; }

        [EnumDataType(typeof(UsageCode))]
        public virtual UsageCode? Usage { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Make")]
        public virtual string Make { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Model")]
        public virtual string Model { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public virtual string Comments { get; set; }

        public virtual int? HowMany { get; set; }       

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
