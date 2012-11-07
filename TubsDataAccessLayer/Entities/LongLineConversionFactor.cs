// -----------------------------------------------------------------------
// <copyright file="LongLineConversionFactor.cs" company="Secretariat of the Pacific Community">
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
    public class LongLineConversionFactor : IAuditable, IEntity
    {
        public virtual int Id { get; set; }

        public virtual LongLineSet FishingSet { get; set; }

        public virtual DateTime? DateOnly { get; set; }

        public virtual string TimeOnly { get; set; }

        public virtual DateTime? Date { get; set; }

        public virtual string LabelNumber { get; set; }

        public virtual string SpeciesCode { get; set; }

        public virtual int? TtLength { get; set; }

        public virtual int? UfLength { get; set; }

        public virtual int? UsLength { get; set; }

        public virtual int? LfLength { get; set; }

        public virtual int? PfLength { get; set; }

        public virtual int? PsLength { get; set; }

        public virtual int? SlLength { get; set; }

        public virtual int? EoLength { get; set; }

        public virtual int? CkLength { get; set; }

        public virtual int? TlLength { get; set; }

        public virtual int? CuLength { get; set; }

        public virtual decimal? WwWeight { get; set; }

        public virtual decimal? HeadWeight { get; set; }

        public virtual decimal? TailWeight { get; set; }

        public virtual decimal? GutsWeight { get; set; }

        public virtual decimal? WetfinWeight { get; set; }

        public virtual decimal ProcessedWeight { get; set; }

        public virtual string ProcessedWeightCode { get; set; }

        public virtual decimal? LandedWeight { get; set; }

        public virtual string LandedWeightCode { get; set; }

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
