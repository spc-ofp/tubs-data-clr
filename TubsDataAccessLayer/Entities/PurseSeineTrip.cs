// -----------------------------------------------------------------------
// <copyright file="PurseSeineTrip.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PurseSeineTrip : Trip
    {
        public PurseSeineTrip()
            : base()
        {
            this.SeaDays = new List<PurseSeineSeaDay>(30);
            this.Crew = new List<PurseSeineCrew>(16);
            this.WellContent = new List<PurseSeineWellContent>(16);
            this.WellReconciliations = new List<PurseSeineWellReconciliation>(24);
        }

        public override Gear GetGear()
        {
            return this.Gear;
        }
        
        public virtual PurseSeineGear Gear { get; set; }

        public virtual PurseSeineVesselAttributes VesselAttributes { get; set; }

        public virtual IList<PurseSeineSeaDay> SeaDays { get; protected internal set; }

        public virtual IList<PurseSeineCrew> Crew { get; protected internal set; }

        public virtual IList<PurseSeineWellContent> WellContent { get; protected internal set; }

        public virtual IList<PurseSeineWellReconciliation> WellReconciliations { get; protected internal set; }

        public virtual void AddSeaDay(PurseSeineSeaDay seaday)
        {
            if (null == seaday)
                return;
            
            seaday.Trip = this;
            this.SeaDays.Add(seaday);
        }

        public virtual void AddCrew(PurseSeineCrew crew)
        {
            if (null == crew)
                return;
            
            crew.Trip = this;
            this.Crew.Add(crew);
        }

        public virtual void AddWellContent(PurseSeineWellContent wellcontent)
        {
            if (null == wellcontent)
                return;
            
            wellcontent.Trip = this;
            this.WellContent.Add(wellcontent);
        }

        public virtual void AddWellReconciliation(PurseSeineWellReconciliation reconciliation)
        {
            if (null == reconciliation)
                return;
            
            reconciliation.Trip = this;
            this.WellReconciliations.Add(reconciliation);
        }
    }
}
