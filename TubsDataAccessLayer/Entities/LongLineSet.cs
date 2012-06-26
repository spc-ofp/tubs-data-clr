// -----------------------------------------------------------------------
// <copyright file="LongLineSet.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// Long line set details as recorded on form LL-3
    /// </summary>
    public class LongLineSet
    {
        public LongLineSet()
        {
            CatchList = new List<LongLineCatch>(); // TODO How many on average?
            ConversionFactors = new List<LongLineConversionFactor>();
            EventList = new List<LongLineSetHaulEvent>();
            NotesList = new List<LongLineSetHaulNote>();
        }
        
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual int? SetNumber { get; set; }

        public virtual bool? WasObserved { get; set; }

        public virtual DateTime? SetDateOnly { get; set; }

        public virtual string SetTimeOnly { get; set; }

        public virtual DateTime? SetDate { get; set; }

        public virtual int? SetId { get; set; } // ???

        public virtual DateTime? UtcSetDateOnly { get; set; }

        public virtual string UtcSetTimeOnly { get; set; }

        public virtual DateTime? UtcSetDate { get; set; }

        public virtual int? HooksPerBasket { get; set; } // hk_bt_flt

        public virtual int? TotalBasketCount { get; set; } // bask_set

        public virtual int? BasketsObserved { get; set; }

        public virtual int? HookCount { get; set; } // hook_set

        public virtual int? EstimatedHookCount { get; set; }

        public virtual int? ObservedHookCount { get; set; }

        public virtual string CalculatedHookCount { get; set; }

        public virtual int? LengthOfFloatline { get; set; } // float_length

        public virtual decimal? LineSettingSpeed { get; set; }

        public virtual string LineSettingSpeedUnit { get; set; }

        public virtual decimal? LineSettingSpeedMetersPerSecond { get; set; }

        public virtual int? BranchlineSetInterval { get; set; } // branch_intvl

        public virtual decimal? MetersBetweenBranchlines { get; set; } // branch_dist

        public virtual decimal? LengthOfBranchlines { get; set; } // branch_length

        public virtual decimal? VesselSpeedForSetting { get; set; }

        public virtual int? SharkLineCount { get; set; }

        public virtual int? SharkLineLength { get; set; }

        public virtual bool? TdrDeployed { get; set; }

        public virtual bool? TargetingTuna { get; set; }

        public virtual bool? TargetingSwordfish { get; set; }

        public virtual bool? TargetingShark { get; set; }

        public virtual string Details { get; set; }

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

        public virtual IList<LongLineCatch> CatchList { get; protected internal set; }

        public virtual IList<LongLineSetHaulEvent> EventList { get; protected internal set; }

        public virtual IList<LongLineConversionFactor> ConversionFactors { get; protected internal set; }

        public virtual IList<LongLineSetHaulNote> NotesList { get; protected internal set; }

        public virtual void AddCatch(LongLineCatch lcatch)
        {
            lcatch.FishingSet = this;
            this.CatchList.Add(lcatch);
        }

        public virtual void AddConversionFactor(LongLineConversionFactor cfactor)
        {
            cfactor.FishingSet = this;
            this.ConversionFactors.Add(cfactor);
        }

        public virtual void AddEvent(LongLineSetHaulEvent levent)
        {
            levent.FishingSet = this;
            this.EventList.Add(levent);
        }

        public virtual void AddNote(LongLineSetHaulNote note)
        {
            note.FishingSet = this;
            this.NotesList.Add(note);
        }
    }
}
