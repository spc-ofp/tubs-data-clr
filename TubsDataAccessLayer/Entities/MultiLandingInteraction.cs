// -----------------------------------------------------------------------
// <copyright file="MultiLandingInteraction.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
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
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Header record for GEN-2 Multilandings
    /// </summary>
    public class MultiLandingInteraction
    {
        public MultiLandingInteraction()
        {
            this.Details = new List<MultiInteractionDetail>(6);
        }
        
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual DateTime? LandedDate { get; set; }

        public virtual DateTime? LandedDateOnly { get; set; }

        public virtual string LandedTimeOnly { get; set; }

        public virtual string MeasuringInstrument { get; set; }

        public virtual bool? ContinuedOnPs4 { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        public virtual string Comments { get; set; }

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

        public virtual IList<MultiInteractionDetail> Details { get; protected internal set; }

        public virtual void AddDetail(MultiInteractionDetail detail)
        {
            detail.Header = this;
            this.Details.Add(detail);
        }
    }
}
