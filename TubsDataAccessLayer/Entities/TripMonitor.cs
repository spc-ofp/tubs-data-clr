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
    using System.Linq;
    using System.Text;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TripMonitor represents the data entered on form GEN-3.
    /// </summary>
    public class TripMonitor
    {
        public TripMonitor()
        {
            this.Details = new List<TripMonitorDetail>();
        }

        public virtual int Id { get; protected set; }

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

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }

        public virtual IList<TripMonitorDetail> Details { get; protected internal set; }

        public virtual void AddDetail(TripMonitorDetail detail)
        {
            detail.Header = this;
            this.Details.Add(detail);
        }
    }
}
