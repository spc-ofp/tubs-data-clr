// -----------------------------------------------------------------------
// <copyright file="TripMonitor.cs"company="Secretariat of the Pacific Community">
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
    /// TripMonitor represents the data entered on form GEN-3.
    /// </summary>
    public class TripMonitor : IAuditable, IEntity
    {
        public TripMonitor()
        {
            this.Details = new List<TripMonitorDetail>();
        }

        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual bool? Question1 { get; set; }

        public virtual bool? Question2 { get; set; }

        public virtual bool? Question3 { get; set; }

        public virtual bool? Question4 { get; set; }

        public virtual bool? Question5 { get; set; }

        public virtual bool? Question6 { get; set; }

        public virtual bool? Question7 { get; set; }

        public virtual bool? Question8 { get; set; }

        public virtual bool? Question9 { get; set; }

        public virtual bool? Question10 { get; set; }

        public virtual bool? Question11 { get; set; }

        public virtual bool? Question12 { get; set; }

        public virtual bool? Question13 { get; set; }

        public virtual bool? Question14 { get; set; }

        public virtual bool? Question15 { get; set; }

        public virtual bool? Question16 { get; set; }

        public virtual bool? Question17 { get; set; }

        public virtual bool? Question18 { get; set; }

        public virtual bool? Question19 { get; set; }

        public virtual bool? Question20 { get; set; }

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

        public virtual IList<TripMonitorDetail> Details { get; protected internal set; }

        public virtual void AddDetail(TripMonitorDetail detail)
        {
            detail.Header = this;
            this.Details.Add(detail);
        }

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
