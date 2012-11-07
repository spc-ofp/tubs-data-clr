// -----------------------------------------------------------------------
// <copyright file="MultiInteractionDetail.cs" company="Secretariat of the Pacific Community">
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
    using System.ComponentModel.DataAnnotations;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// GEN-2 Multiple Interaction detail.
    /// Recorded on a GEN-2 supplement.
    /// </summary>
    public class MultiInteractionDetail : IAuditable, IEntity
    {
        public virtual int Id { get; set; }

        public virtual MultiLandingInteraction Header { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SpeciesCode")]
        [StringLength(3)]
        public virtual string SpeciesCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Length")]
        public virtual decimal? Length { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LengthCode")]
        public virtual LengthCode? LengthCode { get; set; }

        [EnumDataType(typeof(SexCode))]
        [Display(ResourceType = typeof(FieldNames), Name = "SexCode")]
        public virtual SexCode? SexCode { get; set; }

        [EnumDataType(typeof(ConditionCode))]
        [Display(ResourceType = typeof(FieldNames), Name = "ConditionCode")]       
        public virtual ConditionCode? LandedConditionCode { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "ConditionDescription")]
        public virtual string LandedConditionDescription { get; set; }

        [EnumDataType(typeof(ConditionCode))]
        [Display(ResourceType = typeof(FieldNames), Name = "ConditionCode")]
        public virtual ConditionCode? DiscardedConditionCode { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "ConditionDescription")]
        public virtual string DiscardedConditionDescription { get; set; }

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
