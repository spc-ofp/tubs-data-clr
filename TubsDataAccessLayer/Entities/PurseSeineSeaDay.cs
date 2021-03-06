﻿// -----------------------------------------------------------------------
// <copyright file="PurseSeineSeaDay.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Purse Seine sea days.  Different from the generic SeaDay in that it collects
    /// a "diary page" field.
    /// </summary>
    public class PurseSeineSeaDay : SeaDay
    {
        public PurseSeineSeaDay()
        {
            this.Activities = new List<PurseSeineActivity>();
        }

        [Display(ResourceType = typeof(FieldNames), Name = "DiaryPage")]
        public virtual string DiaryPage { get; set; }

        // Using LINQ, it's possible that this list could be filtered by entities allowed to
        // see said activities.  However, what is really wanted is to have these entities filtered
        // at the database level.  Bleah!
        public virtual IList<PurseSeineActivity> Activities { get; protected internal set; }

        public virtual void AddActivity(PurseSeineActivity activity)
        {
            activity.Day = this;
            this.Activities.Add(activity);
        }
    }
}
