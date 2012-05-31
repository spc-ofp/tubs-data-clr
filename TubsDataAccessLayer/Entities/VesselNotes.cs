// -----------------------------------------------------------------------
// <copyright file="VesselNotes.cs" company="Secretariat of the Pacific Community">
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
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Unfortunately, some vessel data is stored in the Trip table.  To keep the Trip object a _little_
    /// cleaner, this vessel data is moved into this class.
    /// </summary>
    public class VesselNotes
    {
        [StringLength(50)]
        [Display(ResourceType = typeof(FieldNames), Name = "VesselOwner")]
        public virtual string Owner { get; set; }

        [StringLength(50)]
        [Display(ResourceType = typeof(FieldNames), Name = "Captain")]
        public virtual string Captain { get; set; }

        [StringLength(2)]
        [Display(ResourceType = typeof(FieldNames), Name = "CaptainCountryCode")]
        public virtual string CaptainCountryCode { get; set; }

        [StringLength(50)]
        [Display(ResourceType = typeof(FieldNames), Name = "FishingMaster")]
        public virtual string FishingMaster { get; set; }

        [StringLength(2)]
        [Display(ResourceType = typeof(FieldNames), Name = "MasterCountryCode")]
        public virtual string MasterCountryCode { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "Licenses")]
        public virtual string Licenses { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        public virtual string Comments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "HasWasteDisposal")]
        public virtual bool HasWasteDisposal { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "WasteDisposalDescription")]
        public virtual string WasteDisposalDescription { get; set; }
    }
}
