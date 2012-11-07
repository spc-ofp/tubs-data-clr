// -----------------------------------------------------------------------
// <copyright file="SeaDay.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class SeaDay : IAuditable, IEntity
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        // This should probably be a key into obsv.ref_forms
        public virtual int? FormId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(ResourceType = typeof(FieldNames), Name = "LocalTime")]
        public virtual DateTime? StartOfDay { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? StartDateOnly { get; set; }

        [StringLength(4)]
        public virtual string StartTimeOnly { get; set; }

        [DataType(DataType.DateTime)]
        [Display(ResourceType = typeof(FieldNames), Name = "UtcTime")]
        public virtual DateTime? UtcStartOfDay { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? UtcDateOnly { get; set; }

        [StringLength(4)]
        public virtual string UtcTimeOnly { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "FloatingObjectsNoSchool")]
        public virtual int? FloatingObjectsNoSchool { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "FloatingObjectsWithSchool")]
        public virtual int? FloatingObjectsWithSchool { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "FadsNoSchool")]
        public virtual int? FadsNoSchool { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "FadsWithSchool")]
        public virtual int? FadsWithSchool { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "FreeSchools")]
        public virtual int? FreeSchools { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Gen3Events")]
        public virtual bool? Gen3Events { get; set; }

        public virtual byte[] RowVersion { get; protected internal set; }

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
