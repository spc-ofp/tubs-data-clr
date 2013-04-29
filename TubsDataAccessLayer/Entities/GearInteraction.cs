// -----------------------------------------------------------------------
// <copyright file="GearInteraction.cs" company="Secretariat of the Pacific Community">
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
    /// GEN-2 interaction for species interacting with vessel or vessel gear.
    /// </summary>
    public class GearInteraction : Interaction
    {
        public GearInteraction()
        {
            this.Details = new List<GearInteractionDetail>(6);
        }
        
        // Interacted with vessel/gear
        public virtual InteractionActivity? InteractionId { get; set; }

        public virtual string InteractionOther { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Description")]
        [DataType(DataType.MultilineText)]
        public virtual string InteractionDescription { get; set; }

        // This goes with Interaction with Vessel/Gear only
        public virtual IList<GearInteractionDetail> Details { get; protected internal set; }

        public virtual void AddDetail(GearInteractionDetail detail)
        {
            detail.Header = this;
            this.Details.Add(detail);
        }
    }
}
