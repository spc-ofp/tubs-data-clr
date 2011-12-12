﻿// -----------------------------------------------------------------------
// <copyright file="ActivityMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Tubs.DAL.Mappings
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
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Fluent NHibernate mapper for classes deriving from Activity.
    /// </summary>
    /// <typeparam name="T">Any class deriving from Activity.</typeparam>
    public abstract class BaseActivityMap<T> : ClassMap<T> where T : Activity
    {
        public BaseActivityMap()
        {
            Map(x => x.LocalTime, "act_dtime");
            Map(x => x.UtcTime, "utc_act_dtime");
            Map(x => x.Latitude, "lat");
            Map(x => x.Longitude, "lon");
            Map(x => x.EezCode, "eez_code");

            // For future reference, the answer to how to map
            // integer enums came from StackOverflow:
            // http://stackoverflow.com/questions/439003/how-do-you-map-an-enum-as-an-int-value-with-fluent-nhibernate
            Map(x => x.DetectionMethod, "deton_id").CustomType(typeof(DetectionMethod));
            Map(x => x.SchoolAssociation, "schas_id").CustomType(typeof(SchoolAssociation));

            Map(x => x.Beacon, "beacon");

            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.Comments, "comments");            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PurseSeineActivityMap : BaseActivityMap<PurseSeineActivity>
    {
        public PurseSeineActivityMap()
        {
            Table("[obsv].[s_daylog]");
            Id(x => x.Id, "s_daylog_id").GeneratedBy.Identity();
            Map(x => x.ActivityType, "s_activ_id").CustomType(typeof(ActivityType));
            Map(x => x.WindDirection, "wind_dir");
            Map(x => x.WindSpeed, "wind_kts");
            Map(x => x.SeaCode, "sea_code");            
            Map(x => x.Payao, "payao");            
            HasOne(x => x.Day).ForeignKey("s_day_id");
            HasOne(x => x.FishingSet).ForeignKey("s_set_id");
        }
    }
}
