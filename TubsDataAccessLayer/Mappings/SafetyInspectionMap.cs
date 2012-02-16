// -----------------------------------------------------------------------
// <copyright file="SafetyInspectionMap.cs" company="Secretariat of the Pacific Community">
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

    /// <summary>
    /// Fluent NHibernate mapping for the SafetyInspection entity.
    /// </summary>
    public sealed class SafetyInspectionMap : ClassMap<SafetyInspection>
    {
        public SafetyInspectionMap()
        {
            Table("obsv.vess_safety");
            Id(x => x.Id, "vess_safety_id").GeneratedBy.Identity();
            Map(x => x.LifejacketProvided, "lj_provided_ans").CustomType(typeof(YesNoType));
            Map(x => x.LifejacketSizeOk, "lj_sizeok_ans").CustomType(typeof(YesNoType));
            Map(x => x.BuoyCount, "buoys_n");
            Component(x => x.Epirb1, m =>
            {
                m.Map(x => x.BeaconType, "epirb1_type");
                m.Map(x => x.Count, "epirb1_n");
                m.Map(x => x.Expiration, "epirb1_exp");
            });
            Component(x => x.Epirb2, m =>
            {
                m.Map(x => x.BeaconType, "epirb2_type");
                m.Map(x => x.Count, "epirb2_n");
                m.Map(x => x.Expiration, "epirb2_exp");
            });
            Component(x => x.Raft1, m =>
            {
                m.Map(x => x.Capacity, "raft1_capac");
                m.Map(x => x.Expiration, "raft1_expiry");
                m.Map(x => x.LastOrDue, "raft1_LD1"); // TODO Needs to be 'raft1_LD', 'raft2_LD'...
            });
            Component(x => x.Raft2, m =>
            {
                m.Map(x => x.Capacity, "raft2_capac");
                m.Map(x => x.Expiration, "raft2_expiry");
                m.Map(x => x.LastOrDue, "raft1_LD2"); // TODO Needs to be 'raft1_LD', 'raft2_LD'...
            });
            Component(x => x.Raft3, m =>
            {
                m.Map(x => x.Capacity, "raft3_capac");
                m.Map(x => x.Expiration, "raft3_expiry");
                m.Map(x => x.LastOrDue, "raft1_LD3"); // TODO Needs to be 'raft1_LD', 'raft2_LD'...
            });
            Component(x => x.Raft4, m =>
            {
                m.Map(x => x.Capacity, "raft4_capac");
                m.Map(x => x.Expiration, "raft4_expiry");
                m.Map(x => x.LastOrDue, "raft1_LD4"); // TODO Needs to be 'raft1_LD', 'raft2_LD'...
            });
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");

            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
