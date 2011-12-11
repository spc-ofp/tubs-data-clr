// -----------------------------------------------------------------------
// <copyright file="ActivityMap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Entities;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
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
            References(x => x.Day).Column("s_day_id");
        }
    }
}
