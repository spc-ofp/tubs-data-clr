// -----------------------------------------------------------------------
// <copyright file="Gen5Object.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Record of a FAD, payao, or other floating object.
    /// </summary>
    public class Gen5Object : IAuditable
    {
        public Gen5Object()
        {
            Materials = new List<Gen5Material>(10);
        }
        
        public virtual int Id { get; set; }

        public virtual PurseSeineActivity Activity { get; set; }

        /// <summary>
        /// ObjectNumber is a sequence number assigned by the observer per trip.
        /// It's intended to allow the tracking of behavior relating to floating
        /// objects that don't carry markings (e.g. a bunch of logs or a dead animal).
        /// </summary>
        public virtual int? ObjectNumber { get; set; }

        public virtual FadOrigin? Origin { get; set; }

        public virtual DateTime? DeploymentDate { get; set; }

        public virtual string Latitude { get; set; }

        public virtual string Longitude { get; set; }

        public virtual bool? IsSsiTrapped { get; set; }

        public virtual FadType? AsFound { get; set; }

        public virtual FadType? AsLeft { get; set; }

        public virtual int? Depth { get; set; }

        public virtual int? Length { get; set; }

        public virtual int? Width { get; set; }

        public virtual string BuoyNumber { get; set; }

        public virtual string Markings { get; set; }

        public virtual string Comments { get; set; }

        public virtual IList<Gen5Material> Materials { get; protected internal set; }

        public virtual IList<FadMaterials> MainMaterials
        {
            get
            {
                return Materials
                    .Where(x => x != null && !x.IsAttachment)
                    .Select(x => x.Material)
                    .ToList();
            }
        }

        public virtual IList<FadMaterials> Attachments
        {
            get
            {
                return Materials
                    .Where(x => x != null && x.IsAttachment)
                    .Select(x => x.Material)
                    .ToList();
            }
        }

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

        public virtual void AddMaterial(Gen5Material material)
        {
            if (null != material)
            {
                material.Fad = this;
                this.Materials.Add(material);
            }
        }
    }
}
