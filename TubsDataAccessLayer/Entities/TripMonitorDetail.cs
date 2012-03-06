// -----------------------------------------------------------------------
// <copyright file="TripMonitorDetail.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// TripMonitorDetail represents the answers for any GEN-3 questions
    /// marked with a "YES".  GEN-3 has 3 spots for answers, but presumably
    /// there's a means for observers to provide more than 3 answers.
    /// </summary>
    public class TripMonitorDetail
    {
        public virtual int Id { get; set; }

        public virtual TripMonitor Header { get; set; }

        public virtual DateTime? DetailDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public virtual string Comments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        public virtual DateTime? EnteredDate { get; set; }
    }
}
