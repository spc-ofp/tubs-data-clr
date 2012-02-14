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
        public PurseSeineTrip() : base()
        {
            this.SeaDays = new List<PurseSeineSeaDay>();
            this.Crew = new List<PurseSeineCrew>();
        }
        
        public virtual IList<PurseSeineSeaDay> SeaDays { get; protected internal set; }

        public virtual IList<PurseSeineCrew> Crew { get; protected internal set; }
        
        public virtual void AddSeaDay(PurseSeineSeaDay seaday)
        {
            System.Console.WriteLine("Calling AddSeaDay");
            seaday.Trip = this;
            this.SeaDays.Add(seaday);
        }

        public virtual void AddCrew(PurseSeineCrew crew)
        {
            crew.Trip = this;
            this.Crew.Add(crew);
        }
    }
}
