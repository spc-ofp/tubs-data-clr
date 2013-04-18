// -----------------------------------------------------------------------
// <copyright file="LandedInteraction.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
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

    /// <summary>
    /// GEN-2 interaction for species landed on deck
    /// </summary>
    public class LandedInteraction : InteractionBase
    {
        // Landed
        [Display(ResourceType = typeof(FieldNames), Name = "ConditionCode")]
        [EnumDataType(typeof(ConditionCode))]
        public virtual ConditionCode? LandedConditionCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ConditionDescription")]
        public virtual string LandedConditionDescription { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LandedHandling")]
        public virtual string LandedHandling { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Length")]
        public virtual decimal? LandedLength { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LengthCode")]
        public virtual LengthCode? LandedLengthCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SexCode")]
        public virtual SexCode? LandedSexCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ConditionCode")]
        public virtual ConditionCode? DiscardedConditionCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ConditionDescription")]
        public virtual string DiscardedConditionDescription { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagNumber")]
        public virtual string RetrievedTagNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagType")]
        public virtual string RetrievedTagType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagOrg")]
        public virtual string RetrievedTagOrganization { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagNumber")]
        public virtual string PlacedTagNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagType")]
        public virtual string PlacedTagType { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TagOrg")]
        public virtual string PlacedTagOrganization { get; set; }
    }
}
