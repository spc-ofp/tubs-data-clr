// -----------------------------------------------------------------------
// <copyright file="Observer.cs"  company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Observer entity.  Sourced from the [ref].[field_staff] view and therefore
    /// read only.
    /// </summary>
    public class Observer
    {
        [Display(ResourceType = typeof(FieldNames), Name = "StaffCode")]
        public virtual string StaffCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "FirstName")]
        public virtual string FirstName { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "LastName")]
        public virtual string LastName { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Join(" ", this.FirstName.NullSafeTrim(), this.LastName.NullSafeTrim()));
            if (!String.IsNullOrEmpty(this.StaffCode))
            {
                sb.AppendFormat(" ({0})", this.StaffCode.Trim());
            }

            return sb.ToString().Trim();
        }
    }
}
