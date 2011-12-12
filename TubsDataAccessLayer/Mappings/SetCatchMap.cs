// -----------------------------------------------------------------------
// <copyright file="SetCatchMap.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <typeparam name="T">Any class deriving from SetCatch.</typeparam>
    public abstract class BaseSetCatchMap<T> : ClassMap<T> where T : SetCatch
    {
        public BaseSetCatchMap()
        {
            Map(x => x.SpeciesCode, "sp_code");
            Map(x => x.FateCode, "fate_code");
            Map(x => x.AverageLength, "avg_len");
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PurseSeineSetCatchMap : BaseSetCatchMap<PurseSeineSetCatch>
    {
        public PurseSeineSetCatchMap()
        {
            Table("[obsv].[s_setcatch]");
            Id(x => x.Id, "s_setcatch_id").GeneratedBy.Identity();
            Map(x => x.ContainsLargeFish, "large_fish");
            Map(x => x.ConditionCode, "cond_code");
            Map(x => x.MetricTonsObserved, "obs_mt");
            Map(x => x.MetricTonsFromLog, "ves_mt");
            Map(x => x.CountObserved, "obs_n");
            Map(x => x.CountFromLog, "ves_n");
            Map(x => x.SpeciesWeightLow, "sp_w_low");
            Map(x => x.SpeciesWeightHigh, "sp_w_high");
            //// Not sure what these are
            Map(x => x.sp_c_spcomp);
            Map(x => x.sp_w_id);
            Map(x => x.sp_c_est);
            Map(x => x.sp_c_id);
            Map(x => x.sp_n_est);
            References(x => x.FishingSet).Column("s_set_id");
        }
    }
}
