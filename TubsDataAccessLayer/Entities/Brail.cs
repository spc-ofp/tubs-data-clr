// -----------------------------------------------------------------------
// <copyright file="Brail.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Infrastructure;
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Brail : IAuditable, IEntity
    {
        /// <summary>
        /// Gets or sets unique entity identifier
        /// </summary>
        [Key]
        public virtual int Id { get; set; }

        /*
         * The problem here is that because of the legacy (MS Access) client,
         * what should normally be rows in a child table are columns in the
         * parent table.  Mapping into a component and then publishing out
         * via another interface is a work-around, not a best practice.
         */

        /// <summary>
        /// Record for brail #1
        /// </summary>
        public virtual BrailRecord Record1 { get; set; }

        /// <summary>
        /// Record for brail #2
        /// </summary>
        public virtual BrailRecord Record2 { get; set; }

        /// <summary>
        /// Record for brail #3
        /// </summary>
        public virtual BrailRecord Record3 { get; set; }

        /// <summary>
        /// Record for brail #4
        /// </summary>
        public virtual BrailRecord Record4 { get; set; }

        /// <summary>
        /// Record for brail #5
        /// </summary>
        public virtual BrailRecord Record5 { get; set; }

        /// <summary>
        /// Record for brail #6
        /// </summary>
        public virtual BrailRecord Record6 { get; set; }

        /// <summary>
        /// Record for brail #7
        /// </summary>
        public virtual BrailRecord Record7 { get; set; }

        /// <summary>
        /// Record for brail #8
        /// </summary>
        public virtual BrailRecord Record8 { get; set; }

        /// <summary>
        /// Record for brail #9
        /// </summary>
        public virtual BrailRecord Record9 { get; set; }

        /// <summary>
        /// Record for brail #10
        /// </summary>
        public virtual BrailRecord Record10 { get; set; }

        /// <summary>
        /// Record for brail #11
        /// </summary>
        public virtual BrailRecord Record11 { get; set; }

        /// <summary>
        /// Record for brail #12
        /// </summary>
        public virtual BrailRecord Record12 { get; set; }

        /// <summary>
        /// Record for brail #13
        /// </summary>
        public virtual BrailRecord Record13 { get; set; }

        /// <summary>
        /// Record for brail #14
        /// </summary>
        public virtual BrailRecord Record14 { get; set; }

        /// <summary>
        /// Record for brail #15
        /// </summary>
        public virtual BrailRecord Record15 { get; set; }

        /// <summary>
        /// Record for brail #16
        /// </summary>
        public virtual BrailRecord Record16 { get; set; }

        /// <summary>
        /// Record for brail #17
        /// </summary>
        public virtual BrailRecord Record17 { get; set; }

        /// <summary>
        /// Record for brail #18
        /// </summary>
        public virtual BrailRecord Record18 { get; set; }

        /// <summary>
        /// Record for brail #19
        /// </summary>
        public virtual BrailRecord Record19 { get; set; }

        /// <summary>
        /// Record for brail #20
        /// </summary>
        public virtual BrailRecord Record20 { get; set; }

        /// <summary>
        /// Record for brail #21
        /// </summary>
        public virtual BrailRecord Record21 { get; set; }

        /// <summary>
        /// Record for brail #22
        /// </summary>
        public virtual BrailRecord Record22 { get; set; }

        /// <summary>
        /// Record for brail #23
        /// </summary>
        public virtual BrailRecord Record23 { get; set; }

        /// <summary>
        /// Record for brail #24
        /// </summary>
        public virtual BrailRecord Record24 { get; set; }

        /// <summary>
        /// Record for brail #25
        /// </summary>
        public virtual BrailRecord Record25 { get; set; }

        /// <summary>
        /// Record for brail #26
        /// </summary>
        public virtual BrailRecord Record26 { get; set; }

        /// <summary>
        /// Record for brail #27
        /// </summary>
        public virtual BrailRecord Record27 { get; set; }

        /// <summary>
        /// Record for brail #28
        /// </summary>
        public virtual BrailRecord Record28 { get; set; }

        /// <summary>
        /// Record for brail #29
        /// </summary>
        public virtual BrailRecord Record29 { get; set; }

        /// <summary>
        /// Record for brail #30
        /// </summary>
        public virtual BrailRecord Record30 { get; set; }

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

        public virtual LengthSamplingHeader Header { get; set; }

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

        /// <summary>
        /// Read-only property making iterating over brail records easier.
        /// Writing back into the entity will still be a pain in the neck.
        /// </summary>
        /// <remarks>
        /// If any caller wants an array, they can do it themselves
        /// via IEnumerable.ToArray()
        /// </remarks>
        public virtual IEnumerable<BrailRecord> BrailRecords
        {
            get
            {
                yield return this.Record1;
                yield return this.Record2;
                yield return this.Record3;
                yield return this.Record4;
                yield return this.Record5;
                yield return this.Record6;
                yield return this.Record7;
                yield return this.Record8;
                yield return this.Record9;
                yield return this.Record10;
                yield return this.Record11;
                yield return this.Record12;
                yield return this.Record13;
                yield return this.Record14;
                yield return this.Record15;
                yield return this.Record16;
                yield return this.Record17;
                yield return this.Record18;
                yield return this.Record19;
                yield return this.Record20;
                yield return this.Record21;
                yield return this.Record22;
                yield return this.Record23;
                yield return this.Record24;
                yield return this.Record25;
                yield return this.Record26;
                yield return this.Record27;
                yield return this.Record28;
                yield return this.Record29;
                yield return this.Record30;
            }
        }
    }

    /// <summary>
    /// A brail record consists of an integer triple for recording
    /// amount of catch and number of samples measured.
    /// </summary>
    public sealed class BrailRecord
    {
        /// <summary>
        /// When was this brail brought on board?
        /// </summary>
        /// <remarks>
        /// A single PS-4 page only has slots for 30 brails.
        /// </remarks>
        [RangeAttribute(1, 30)]
        public int Sequence { get; set; }

        /// <summary>
        /// The number of samples retrieved from this brail.
        /// </summary>
        [RangeAttribute(0, Int32.MaxValue)]
        public int? Samples { get; set; }

        /// <summary>
        /// Code for brail fullness:  1 = 1/8th, 1 = Full
        /// </summary>
        [RangeAttribute(1, 8)]
        public int? Fullness { get; set; }
    }
}
