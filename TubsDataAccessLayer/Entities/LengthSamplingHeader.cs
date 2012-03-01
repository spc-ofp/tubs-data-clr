// -----------------------------------------------------------------------
// <copyright file="LengthSamplingHeader.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LengthSamplingHeader
    {
        public LengthSamplingHeader()
        {
            this.Samples = new List<LengthSample>();
            this.Brails = new List<Brail>();
        }

        public virtual int Id { get; set; }

        public virtual int? FormId { get; set; }

        public virtual SamplingProtocol? SamplingProtocol { get; set; } // Protocol type, switch to enum

        public virtual string SamplingProtocolComments { get; set; }

        public virtual string BrailStartTime { get; set; }

        public virtual string BrailEndTime { get; set; }

        public virtual PurseSeineSet Set { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }

        public virtual IList<LengthSample> Samples { get; protected internal set; }

        public virtual IList<Brail> Brails { get; protected internal set; }

        public virtual void AddLengthSample(LengthSample sample)
        {
            sample.Header = this;
            this.Samples.Add(sample);
        }

        public virtual void AddBrail(Brail brail)
        {
            brail.Header = this;
            this.Brails.Add(brail);
        }
    }
}
