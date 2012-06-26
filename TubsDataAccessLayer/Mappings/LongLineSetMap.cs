// -----------------------------------------------------------------------
// <copyright file="LongLineSetMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
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
    using Spc.Ofp.Tubs.DAL.Entities;
    using Spc.Ofp.Tubs.DAL.Common;

    /// <summary>
    /// Fluent NHibernate mapping for the LongLineSet entity.
    /// </summary>
    public class LongLineSetMap : ClassMap<LongLineSet>
    {
        public LongLineSetMap()
        {
            Schema("obsv");
            Table("l_set");
            Id(x => x.Id, "s_set_id").GeneratedBy.Identity();
            Map(x => x.SetNumber, "set_number");
            Map(x => x.WasObserved, "observed_yn").CustomType<YesNoType>();
            Map(x => x.SetDateOnly, "set_date");
            Map(x => x.SetTimeOnly, "set_time");
            Map(x => x.SetDate, "set_dtime");
            Map(x => x.UtcSetDateOnly, "utc_set_date");
            Map(x => x.UtcSetTimeOnly, "utc_set_time");
            Map(x => x.UtcSetDate, "utc_set_dtime");
            Map(x => x.HooksPerBasket, "hk_bt_flt");
            Map(x => x.TotalBasketCount, "bask_set");
            Map(x => x.BasketsObserved, "bask_observed");
            Map(x => x.HookCount, "hook_set");
            Map(x => x.EstimatedHookCount, "hook_est");
            Map(x => x.ObservedHookCount, "hook_observed");
            Map(x => x.CalculatedHookCount, "hook_calc"); // This isn't correct
            Map(x => x.LengthOfFloatline, "float_length");
            Map(x => x.LineSettingSpeed, "lspeed").Precision(5).Scale(1);
            Map(x => x.LineSettingSpeedUnit, "lspeed_unit3_id").CustomType<UnitOfMeasure>(); // This needs fixing, should be int
            Map(x => x.LineSettingSpeedMetersPerSecond, "lspeed_mpersec").Precision(5).Scale(1);
            Map(x => x.BranchlineSetInterval, "branch_intvl");
            Map(x => x.MetersBetweenBranchlines, "branch_dist");

            Map(x => x.Details, "setdetails");
            Map(x => x.EnteredBy, "entered_by").Length(20);
            Map(x => x.EnteredDate, "entered_dtime");
            Map(x => x.UpdatedBy, "updated_by").Length(20);
            Map(x => x.UpdatedDate, "updated_dtime");
            Map(x => x.DctNotes, "dct_notes");
            Map(x => x.DctScore, "dct_score");

            HasMany(x => x.CatchList).KeyColumn("l_set_id").Cascade.None();
            HasMany(x => x.EventList).KeyColumn("l_set_id").Cascade.None();
            HasMany(x => x.ConversionFactors).KeyColumn("l_set_id").Cascade.None();
            HasMany(x => x.NotesList).KeyColumn("l_set_id").Cascade.None();
        }
    }
}
