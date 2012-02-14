// -----------------------------------------------------------------------
// <copyright file="PollutionEvent.cs" company="Secretariat of the Pacific Community">
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
    /// PollutionEvent represents the top and bottom of Form GEN-6.
    /// </summary>
    public class PollutionEvent
    {
        public PollutionEvent()
        {
            this.Details = new List<PollutionDetail>();
        }
        
        public virtual int Id { get; protected set; }

        public virtual Trip Trip { get; set; }

        public virtual int? FormId { get; set; }

        public virtual DateTime? IncidentDate { get; set; }

        public virtual string Latitude { get; set; }

        public virtual string Longitude { get; set; }

        public virtual int? WindDirection { get; set; }

        public virtual int? WindSpeed { get; set; }

        public virtual SeaCode? SeaCode { get; set; }

        public virtual decimal? CurrentSpeed { get; set; }

        public virtual int? CurrentDirection { get; set; }

        public virtual ActivityType? ActivityType { get; set; }

        public virtual int? Bearing { get; set; }

        public virtual int? Distance { get; set; }

        public virtual string Comments { get; set; }

        public virtual bool? MarpolStickers { get; set; }

        public virtual bool? CaptainAware { get; set; }

        public virtual bool? CaptainAdvised { get; set; }

        public virtual bool? PhotosTaken { get; set; }

        public virtual string PhotoFrames { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }

        public virtual IList<PollutionDetail> Details { get; protected internal set; }

        public virtual void AddDetail(PollutionDetail detail)
        {
            detail.Header = this;
            this.Details.Add(detail);
        }
    }
}
