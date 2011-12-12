// -----------------------------------------------------------------------
// <copyright file="Port.cs" company="Secretariat of the Pacific Community">
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
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Port
    {
        [Display(ResourceType = typeof(FieldNames), Name = "PortCode")]
        public virtual string PortCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Name")]
        public virtual string Name { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "AlternateName")]
        public virtual string AlternateName { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "CountryCode")]
        public virtual string CountryCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Latitude")]
        public virtual string Latitude { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Longitude")]
        public virtual string Longitude { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(this.Name))
            {
                sb.Append(this.Name);
            }

            sb.AppendFormat(" ({0})", this.PortCode);
            return sb.ToString().Trim();
        }
    }
}
