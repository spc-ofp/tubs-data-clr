// -----------------------------------------------------------------------
// <copyright file="SafetyInspection.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vessel safety information.  Includes lifejacket questions,
    /// EPIRB inspection, and liferaft inspection.
    /// </summary>
    public class SafetyInspection
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LifejacketProvided")]
        public virtual bool? LifejacketProvided { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LifejacketSizeOk")]
        public virtual bool? LifejacketSizeOk { get; set; }

        // TODO Change to enum of Easy/Moderate/Hard
        [Display(ResourceType = typeof(FieldNames), Name = "LifejacketAvailability")]
        public virtual string LifejacketAvailability { get; set; }

        public virtual int? BuoyCount { get; set; }

        // This should always be a 406 beacon
        public virtual EpirbResult Epirb1 { get; set; }

        // This is for non-406 beacons
        public virtual EpirbResult Epirb2 { get; set; }

        public virtual RaftResult Raft1 { get; set; }

        public virtual RaftResult Raft2 { get; set; }

        public virtual RaftResult Raft3 { get; set; }

        public virtual RaftResult Raft4 { get; set; }

        public virtual IEnumerable<RaftResult> LifeRafts
        {
            get
            {
                return
                    from raft in new RaftResult[] { Raft1, Raft2, Raft3, Raft4 }
                    where null != raft && raft.Include
                    select raft;
            }
        }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }
    }

    public class EpirbResult
    {
        public virtual string BeaconType { get; set; }

        public virtual int? Count { get; set; }

        public virtual string Expiration { get; set; }
    }

    public class RaftResult
    {
        [Display(ResourceType = typeof(FieldNames), Name = "Capacity")]
        public virtual int? Capacity { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "InspectionDate")]
        [DataType(DataType.Date)]
        public virtual DateTime? InspectionDate { get; set;  }
        
        // TODO Constrain this to "L" or "D"
        public virtual char? LastOrDue { get; set; }

        public virtual bool Include
        {
            get
            {
                return this.Capacity.HasValue || this.InspectionDate.HasValue || this.LastOrDue.HasValue;
            }
        }
    }
}
