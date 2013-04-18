// -----------------------------------------------------------------------
// <copyright file="SightingInteraction.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;

    /// <summary>
    /// GEN-2 interaction for species that are sighted only.
    /// </summary>
    public class SightingInteraction : Interaction
    {
        public virtual InteractionActivity? InteractionActivity { get; set; }

        public virtual string InteractionIfOther { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingCount")]
        public virtual int? SightingCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingAdultCount")]
        public virtual int? SightingAdultCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingJuvenileCount")]
        public virtual int? SightingJuvenileCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingLength")]
        public virtual string SightingLength { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "SightingDistance")]
        public virtual decimal? SightingDistance { get; set; }

        public virtual UnitOfMeasure? SightingDistanceUnit { get; set; }

        public virtual decimal SightingDistanceInNm { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual string SightingBehavior { get; set; }
    }
}
