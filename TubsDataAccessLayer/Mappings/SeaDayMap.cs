﻿// -----------------------------------------------------------------------
// <copyright file="SeaDayMap.cs" company="Secretariat of the Pacific Community">
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
    using System;
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Entities;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Mapper for purse seine and pole and line sea days.
    /// </summary>
    /// <typeparam name="T">Any class deriving from SeaDay.</typeparam>
    public abstract class BaseSeaDayMap<T> : ClassMap<T> where T : SeaDay
    {
        protected BaseSeaDayMap() 
        {
            Map(x => x.FormId, "form_id");
            Map(x => x.StartOfDay, "start_dtime");
            Map(x => x.StartDateOnly, "start_date");
            Map(x => x.StartTimeOnly, "start_time").Length(4);
            Map(x => x.UtcStartOfDay, "utc_start_dtime");
            Map(x => x.UtcDateOnly, "utc_start_date");
            Map(x => x.UtcTimeOnly, "utc_start_time").Length(4);
            Map(x => x.FloatingObjectsNoSchool, "log_nofish_n");
            Map(x => x.FloatingObjectsWithSchool, "log_fish_n");
            Map(x => x.FadsNoSchool, "fad_nofish_n");
            Map(x => x.FadsWithSchool, "fad_fish_n");
            Map(x => x.FreeSchools, "sch_fish_n");
            Map(x => x.Gen3Events, "gen3today_ans").CustomType<YesNoType>();
            Map(x => x.EnteredBy, "entered_by").Length(50);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(50);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            // TODO Devise a test for this
            //OptimisticLock.Version();
            //Version(x => x.RowVersion).Column("tstamp").Not.Nullable().CustomSqlType("timestamp").Generated.Always();

            References(x => x.Trip).Column("obstrip_id");
        }      
    }

    /// <summary>
    /// Mapping for purse seine seaday.
    /// </summary>
    public sealed class PurseSeineSeaDayMap : BaseSeaDayMap<PurseSeineSeaDay>
    {
        public PurseSeineSeaDayMap()
        {
            Schema("obsv");
            Table("s_day");
            Id(x => x.Id, "s_day_id")
                .GeneratedBy.Identity()
                .Not.Nullable();
                
            Map(x => x.DiaryPage, "diarypage");
            HasMany(x => x.Activities)
                .KeyColumn("s_day_id")
                .Inverse() // Activities are responsible for saving themselves
                .Cascade.None();
                //.Not.LazyLoad();
            // Dick around with this:
            // http://stackoverflow.com/questions/9904507/explicit-value-for-identity-column-error-on-insert-with-nhibernate-relationship
        }
    }
}
