// -----------------------------------------------------------------------
// <copyright file="SeaDayMap.cs" company="">
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

    /// <summary>
    /// Mapper for purse seine and pole and line sea days.
    /// </summary>
    public abstract class BaseSeaDayMap<T> : ClassMap<T> where T : SeaDay
    {
        public BaseSeaDayMap() 
        {
            Map(x => x.FormId, "form_id");
            Map(x => x.StartOfDay, "start_dtime");
            Map(x => x.UtcStartOfDay, "utc_start_dtime");
            Map(x => x.FloatingObjectsNoSchool, "log_nofish_n");
            Map(x => x.FloatingObjectsWithSchool, "log_fish_n");
            Map(x => x.FadsNoSchool, "fad_nofish_n");
            Map(x => x.FadsWithSchool, "fad_fish_n");
            Map(x => x.FreeSchools, "sch_fish_n");
            Map(x => x.Gen3Events, "gen3today_ans");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Trip).Column("obstrip_id");
        }
       
    }

    public class PurseSeineSeaDayMap : BaseSeaDayMap<PurseSeineSeaDay>
    {
        public PurseSeineSeaDayMap()
        {
            Table("[obsv].[s_day]");
            Id(x => x.Id, "s_day_id").GeneratedBy.Identity();
            Map(x => x.DiaryPage, "diarypage");
            HasMany(x => x.Activities).KeyColumn("s_day_id");
        }
    }
}
