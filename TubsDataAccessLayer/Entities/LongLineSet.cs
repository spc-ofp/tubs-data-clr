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
    using Spc.Ofp.Tubs.DAL.Common;

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
            Baskets = new List<LongLineBasket>();
        }
        
        public virtual int Id { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual int? SetNumber { get; set; }

        public virtual bool? WasObserved { get; set; }

        public virtual DateTime? SetDateOnly { get; set; }

        public virtual string SetTimeOnly { get; set; }

        public virtual DateTime? SetDate { get; set; }

        public virtual int? SetId { get; set; } // Legacy data

        public virtual DateTime? UtcSetDateOnly { get; set; }

        public virtual string UtcSetTimeOnly { get; set; }

        public virtual DateTime? UtcSetDate { get; set; }

        public virtual string LocalTime { get; set; }

        public virtual string TargetSpeciesCode { get; set; }

        // FoxPro uses one field for the next 3 booleans
        public virtual bool? IsTargetingTuna { get; set; }

        public virtual bool? IsTargetingSwordfish { get; set; }

        public virtual bool? IsTargetingSharks { get; set; }

        [Range(0, 50, ErrorMessageResourceName="HooksBetweenBasketsRangeError")]
        public virtual int? HooksPerBasket { get; set; } // hk_bt_flt

        [Range(0, 400, ErrorMessageResourceName="BasketRangeError")]
        public virtual int? TotalBasketCount { get; set; } // bask_set

        [Range(0, 4500, ErrorMessageResourceName="HookRangeError")]
        public virtual int? TotalHookCount { get; set; }

        public virtual int? EstimatedHookCount { get; set; }

        [Range(5, 50, ErrorMessageResourceName="FloatlineRangeError")]
        public virtual int? FloatlineLength { get; set; }

        public virtual int? FloatlineHookCount { get; set; } // ???

        public virtual decimal? LineSettingSpeed { get; set; }

        public virtual UnitOfMeasure? LineSettingSpeedUnit { get; set; }

        [Range(0, 40)]
        public virtual decimal? LineSettingSpeedMetersPerSecond { get; set; } // TUBS but not FoxPro

        public virtual decimal? VesselSpeed { get; set; }

        public virtual int? BranchlineSetInterval { get; set; } // branch_intvl

        [Range(0, 250)]
        public virtual decimal? DistanceBetweenBranchlines { get; set; } // branch_dist

        [Range(5, 50)]
        public virtual decimal? BranchlineLength { get; set; } // branch_length

        public virtual int? SharkLineCount { get; set; }

        public virtual int? SharkLineLength { get; set; }

        public virtual bool? TdrDeployed { get; set; } // TDR is Temperate Depth Recorder

        public virtual int? TotalHooksObserved { get; set; }

        public virtual int? TotalBasketsObserved { get; set; }

        public virtual int? LightStickCount { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Gen3Events")]
        public virtual bool? Gen3Events { get; set; }

        public virtual bool? AllPositionsDirectlyObserved { get; set; }

        public virtual string MeasuringInstrument { get; set; } // TODO Replace with Enum

        public virtual string BaitSpecies1Code { get; set; }
        public virtual int? BaitSpecies1Weight { get; set; }
        public virtual string BaitSpecies1Hooks { get; set; }

        public virtual string BaitSpecies2Code { get; set; }
        public virtual int? BaitSpecies2Weight { get; set; }
        public virtual string BaitSpecies2Hooks { get; set; }

        public virtual string BaitSpecies3Code { get; set; }
        public virtual int? BaitSpecies3Weight { get; set; }
        public virtual string BaitSpecies3Hooks { get; set; }

        public virtual string BaitSpecies4Code { get; set; }
        public virtual int? BaitSpecies4Weight { get; set; }
        public virtual string BaitSpecies4Hooks { get; set; }

        public virtual string BaitSpecies5Code { get; set; }
        public virtual int? BaitSpecies5Weight { get; set; }
        public virtual string BaitSpecies5Hooks { get; set; }

        public virtual string Details { get; set; }

        public virtual string Strategy { get; set; }

        // These appear to be legacy data
        public virtual string HookCalc { get; set; } // Available values are 'E', 'N', or null

        public virtual int? HookDepthLow { get; set; } // Shallowest hook

        public virtual int? HookDepthHigh { get; set; } // Deepest hook

        //br_* are for 1996 workbook revision
        public virtual int? BranchlineCount_00to20m { get; set; }

        public virtual int? BranchlineCount_20to34m { get; set; }

        public virtual int? BranchlineCount_35to50m { get; set; }

        public virtual int? BranchlineCount_50to99m { get; set; }

        /// <summary>
        /// Get or set the value of HasRecordedData.
        /// Indicates if data was recorded with this observed set.  Primarily for AFMA data.
        /// </summary>
        public virtual bool? HasRecordedData { get; set; }

        public virtual string DiaryPage { get; set; } // It's not a mistake that this is a string...

        public virtual int? TdrLength { get; set; }

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

        public virtual IList<LongLineBasket> Baskets { get; protected internal set; }

        public virtual void AddCatch(LongLineCatch lcatch)
        {
            if (null == lcatch)
                return;

            lcatch.FishingSet = this;
            this.CatchList.Add(lcatch);
        }

        public virtual void AddConversionFactor(LongLineConversionFactor cfactor)
        {
            if (null == cfactor)
                return;

            cfactor.FishingSet = this;
            this.ConversionFactors.Add(cfactor);
        }

        public virtual void AddEvent(LongLineSetHaulEvent levent)
        {
            if (null == levent)
                return;
            
            levent.FishingSet = this;
            this.EventList.Add(levent);
        }

        public virtual void AddNote(LongLineSetHaulNote note)
        {
            if (null == note)
                return;
            
            note.FishingSet = this;
            this.NotesList.Add(note);
        }

        public virtual void AddBasket(LongLineBasket basket)
        {
            if (null == basket)
                return;
            
            basket.FishingSet = this;
            this.Baskets.Add(basket);
        }
    }
}
