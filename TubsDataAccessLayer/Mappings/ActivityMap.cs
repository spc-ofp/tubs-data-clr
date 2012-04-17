// -----------------------------------------------------------------------
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
        protected BaseActivityMap()
        {
            Map(x => x.LocalTime, "act_dtime");
            Map(x => x.UtcTime, "utc_act_dtime");
            Map(x => x.Latitude, "lat").Length(9);
            Map(x => x.Longitude, "lon").Length(10);
            Map(x => x.EezCode, "eez_code").Length(2);
            Map(x => x.DetectionMethod, "deton_id").CustomType(typeof(DetectionMethod));
            Map(x => x.SchoolAssociation, "schas_id").CustomType(typeof(SchoolAssociation));

            Map(x => x.Beacon, "beacon").Length(8);

            // TODO Devise a test for this
            //OptimisticLock.Version();
            //Version(x => x.RowVersion).Column("tstamp").Not.Nullable().CustomSqlType("timestamp").Generated.Always();

            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");
            Map(x => x.Comments, "comments"); 
        }
    }

    /// <summary>
    /// Fluent NHibernate mapper for purse seine activities.  
    /// </summary>
    public sealed class PurseSeineActivityMap : BaseActivityMap<PurseSeineActivity>
    {
        public PurseSeineActivityMap()
        {
            Schema("obsv");
            Table("s_daylog");
            Id(x => x.Id, "s_daylog_id")
                .GeneratedBy.Identity()
                .Not.Nullable();
                //.Default(0)
                //.UnsavedValue(0)
                //.Index("[s_daylog$primarykey]");
            Map(x => x.ActivityType, "s_activ_id").CustomType(typeof(ActivityType));
            Map(x => x.WindDirection, "wind_dir");
            Map(x => x.WindSpeed, "wind_kts");
            Map(x => x.SeaCode, "sea_code");          
            Map(x => x.Payao, "payao").Length(8);
            References(x => x.Day)
                .Column("s_day_id")
                .Not.LazyLoad();

            HasOne(x => x.FishingSet).PropertyRef(r => r.Activity).Cascade.All();
        }
    }
}
