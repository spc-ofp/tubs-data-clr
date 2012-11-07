// -----------------------------------------------------------------------
// <copyright file="PurseSeineWellReconciliation.cs" company="Secretariat of the Pacific Community">
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
    /// Might need to create an abstract base class for use with larger long liners.
    /// </summary>
    public class PurseSeineWellReconciliation : IAuditable, IEntity
    {
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual int? FormId { get; set; } // ???

        [DataType(DataType.DateTime)]
        public virtual DateTime? ObserverDate { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? ObserverDateOnly { get; set; }

        public virtual string ObserverTimeOnly { get; set; }

        [DataType(DataType.DateTime)]
        public virtual DateTime? LogsheetDate { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? LogsheetDateOnly { get; set; }

        public virtual string LogsheetTimeOnly { get; set; }

        public virtual ActionType? ActionCode { get; set; }

        public virtual decimal? PortWell1 { get; set; }

        public virtual decimal? StarboardWell1 { get; set; }

        public virtual decimal? PortWell2 { get; set; }

        public virtual decimal? StarboardWell2 { get; set; }

        public virtual decimal? PortWell3 { get; set; }

        public virtual decimal? StarboardWell3 { get; set; }

        public virtual decimal? PortWell4 { get; set; }

        public virtual decimal? StarboardWell4 { get; set; }

        public virtual decimal? PortWell5 { get; set; }

        public virtual decimal? StarboardWell5 { get; set; }

        public virtual decimal? PortWell6 { get; set; }

        public virtual decimal? StarboardWell6 { get; set; }

        public virtual decimal? PortWell7 { get; set; }

        public virtual decimal? StarboardWell7 { get; set; }

        public virtual decimal? PortWell8 { get; set; }

        public virtual decimal? StarboardWell8 { get; set; }

        public virtual decimal? PortWell9 { get; set; }

        public virtual decimal? StarboardWell9 { get; set; }

        public virtual decimal? PortWell10 { get; set; }

        public virtual decimal? StarboardWell10 { get; set; }

        public virtual decimal? PortWell11 { get; set; }

        public virtual decimal? StarboardWell11 { get; set; }

        public virtual decimal? PortWell12 { get; set; }

        public virtual decimal? StarboardWell12 { get; set; }

        public virtual decimal? PortWell13 { get; set; }

        public virtual decimal? StarboardWell13 { get; set; }

        public virtual decimal? PortWell14 { get; set; }

        public virtual decimal? StarboardWell14 { get; set; }

        public virtual decimal? PortWell15 { get; set; }

        public virtual decimal? StarboardWell15 { get; set; }

        public virtual decimal? PortWell16 { get; set; }

        public virtual decimal? StarboardWell16 { get; set; }

        public virtual decimal? PortWell17 { get; set; }

        public virtual decimal? StarboardWell17 { get; set; }

        public virtual decimal? PortWell18 { get; set; }

        public virtual decimal? StarboardWell18 { get; set; }

        public virtual decimal? PortWell19 { get; set; }

        public virtual decimal? StarboardWell19 { get; set; }

        public virtual decimal? PortWell20 { get; set; }

        public virtual decimal? StarboardWell20 { get; set; }

        public virtual decimal? PortWell21 { get; set; }

        public virtual decimal? StarboardWell21 { get; set; }

        public virtual decimal? PortWell22 { get; set; }

        public virtual decimal? StarboardWell22 { get; set; }

        public virtual decimal? PortWell23 { get; set; }

        public virtual decimal? StarboardWell23 { get; set; }

        public virtual decimal? PortWell24 { get; set; }

        public virtual decimal? StarboardWell24 { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ObserversTotal")]
        public virtual decimal? ObserversTotal { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "CumulativeTotal")]
        public virtual decimal? CumulativeTotal { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        public virtual string Comments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [DataType(DataType.DateTime)]
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
