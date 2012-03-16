// -----------------------------------------------------------------------
// <copyright file="CrewMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the Crew entity.
    /// </summary>
    /// <typeparam name="T">Any class deriving from Crew.</typeparam>
    public abstract class BaseCrewMap<T> : ClassMap<T> where T : Crew
    {
        protected BaseCrewMap()
        {
            References(x => x.Trip).Column("obstrip_id");
            Map(x => x.Job, "vsjob_id").CustomType(typeof(JobType));
            Map(x => x.Name, "name");
            Map(x => x.CountryCode, "country_code");
            Map(x => x.YearsExperience, "exp_yr");
            Map(x => x.MonthsExperience, "exp_mo");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");
        }
    }

    /// <summary>
    /// No idea why this is really necessary, but for now I'm (mostly) living with the
    /// structure that was provided.
    /// </summary>
    public sealed class PurseSeineCrewMap : BaseCrewMap<PurseSeineCrew>
    {
        public PurseSeineCrewMap()
        {
            Schema("obsv");
            Table("s_crew");
            Id(x => x.Id, "s_crew_id").GeneratedBy.Identity();
        }
    }
}
