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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SafetyInspection
    {
        public virtual int Id { get; protected set; }

        // TODO Add reference to Trip -- need to fix PK first

        public virtual bool? LifejacketProvided { get; set; }

        public virtual bool? LifejacketSizeOk { get; set; }

        public virtual string LifejacketAvailability { get; set; }

        public virtual int? BuoyCount { get; set; }

        public virtual EpirbResult Epirb1 { get; set; }

        public virtual EpirbResult Epirb2 { get; set; }

        public virtual RaftResult Raft1 { get; set; }

        public virtual RaftResult Raft2 { get; set; }

        public virtual RaftResult Raft3 { get; set; }

        public virtual RaftResult Raft4 { get; set; }

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
        public virtual int? Capacity { get; set; }
        public virtual DateTime? Expiration { get; set;  }
        public virtual char? LastOrDue { get; set; }
    }
}
