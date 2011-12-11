// -----------------------------------------------------------------------
// <copyright file="PurseSeineActivity.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// 
// This file is part of TUBS.
// 
//  TUBS is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// TUBS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PurseSeineActivity : Activity
    {
        public virtual PurseSeineSeaDay Day { get; set; }
        public virtual decimal? FishDays { get; set; } // ???
        
        public virtual string Payao { get; set; }
        public virtual int WindDirection { get; set; }
        public virtual int WindSpeed { get; set; }
        public virtual string SeaCode { get; set; }

        // This should only happen when the activity code is ActivityType.Fishing
        public virtual PurseSeineSet FishingSet { get; set; }
    }
}
