// -----------------------------------------------------------------------
// <copyright file="PurseSeineActivity.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using System.Linq.Expressions;
    using Newtonsoft.Json;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Infrastructure;
    using Spc.Ofp.Tubs.DAL.Security;

    /// <summary>
    /// PurseSeineActivity represents a single PS-2 form line item.
    /// </summary>
    public class PurseSeineActivity : Activity, ISecurable
    {
        public static readonly Expression<Func<PurseSeineActivity, string, bool>> IsAllowedExpression =
            (x, name) => x.AccessControl.Where(ace => name.Equals(ace.EntityName, StringComparison.InvariantCultureIgnoreCase)).Any();

        private static readonly Func<PurseSeineActivity, string, bool> IsAllowedFunc = IsAllowedExpression.Compile();
        
        public PurseSeineActivity()
        {
            this.AccessControl = new List<ActivityAce>(8);
        }
        
        public virtual PurseSeineSeaDay Day { get; set; }

        public virtual decimal? FishDays { get; set; } // ???
        
        public virtual string Payao { get; set; }

        [Range(0, 360)]
        [Display(ResourceType = typeof(FieldNames), Name = "WindDirection")]
        public virtual int? WindDirection { get; set; }

        [Range(0, Int32.MaxValue)]
        [Display(ResourceType = typeof(FieldNames), Name = "WindSpeed")]
        public virtual int? WindSpeed { get; set; }

        [EnumDataType(typeof(SeaCode))]
        [Display(ResourceType = typeof(FieldNames), Name = "SeaCode")]
        public virtual SeaCode? SeaCode { get; set; }

        // This is only present when the ActivityType is related to a FAD
        // (10D, 10R, 15D, 15R, or 9)
        public virtual Gen5Object Fad { get; set; }

        // This should only happen when the activity code is ActivityType.Fishing
        public virtual PurseSeineSet FishingSet { get; set; }

        // Not set on the base class as it may happen that PS is protected but PL isn't.
        // Don't export security
        [JsonIgnore]
        public virtual IList<ActivityAce> AccessControl { get; protected internal set; }

        public virtual IEnumerable<IAccessControl> AccessControlList
        {
            get
            {
                return null == this.AccessControl ?
                    Enumerable.Empty<IAccessControl>() :
                    this.AccessControl.Cast<IAccessControl>();
            }
        }

        public virtual bool IsAllowed(string entityName)
        {
            return IsAllowedFunc(this, entityName);
        }
    }
}
