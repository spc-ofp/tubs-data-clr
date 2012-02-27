// -----------------------------------------------------------------------
// <copyright file="PurseSeineWellReconciliationMap.cs" company="Secretariat of the Pacific Community">
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
    using Spc.Ofp.Tubs.DAL.Common;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Fluent NHibernate mapping for the PurseSeineWellReconciliation entity.
    /// </summary>
    public sealed class PurseSeineWellReconciliationMap : ClassMap<PurseSeineWellReconciliation>
    {
        public PurseSeineWellReconciliationMap()
        {
            Schema("obsv");
            Table("s_log_well_recon");
            Id(x => x.Id, "lw_id").GeneratedBy.Identity();
            Map(x => x.FormId, "form_id");
            Map(x => x.ObserverDate, "obs_dtime");
            Map(x => x.ObserverDateOnly, "obs_date");
            Map(x => x.ObserverTimeOnly, "obs_time");
            Map(x => x.LogsheetDate, "log_dtime");
            Map(x => x.LogsheetDateOnly, "log_date");
            Map(x => x.LogsheetTimeOnly, "log_time");
            Map(x => x.ActionCode, "action_code");
            Map(x => x.PortWell1, "pw1").Precision(8).Scale(3);
            Map(x => x.StarboardWell1, "sw1").Precision(8).Scale(3);
            Map(x => x.PortWell2, "pw2").Precision(8).Scale(3);
            Map(x => x.StarboardWell2, "sw2").Precision(8).Scale(3);
            Map(x => x.PortWell3, "pw3").Precision(8).Scale(3);
            Map(x => x.StarboardWell3, "sw3").Precision(8).Scale(3);
            Map(x => x.PortWell4, "pw4").Precision(8).Scale(3);
            Map(x => x.StarboardWell4, "sw4").Precision(8).Scale(3);
            Map(x => x.PortWell5, "pw5").Precision(8).Scale(3);
            Map(x => x.StarboardWell5, "sw5").Precision(8).Scale(3);
            Map(x => x.PortWell6, "pw6").Precision(8).Scale(3);
            Map(x => x.StarboardWell6, "sw6").Precision(8).Scale(3);
            Map(x => x.PortWell7, "pw7").Precision(8).Scale(3);
            Map(x => x.StarboardWell7, "sw7").Precision(8).Scale(3);
            Map(x => x.PortWell8, "pw8").Precision(8).Scale(3);
            Map(x => x.StarboardWell8, "sw8").Precision(8).Scale(3);
            Map(x => x.PortWell9, "pw9").Precision(8).Scale(3);
            Map(x => x.StarboardWell9, "sw9").Precision(8).Scale(3);
            Map(x => x.PortWell10, "pw10").Precision(8).Scale(3);
            Map(x => x.StarboardWell10, "sw10").Precision(8).Scale(3);
            Map(x => x.PortWell11, "pw11").Precision(8).Scale(3);
            Map(x => x.StarboardWell11, "sw11").Precision(8).Scale(3);
            Map(x => x.PortWell12, "pw12").Precision(8).Scale(3);
            Map(x => x.StarboardWell12, "sw12").Precision(8).Scale(3);
            Map(x => x.PortWell13, "pw13").Precision(8).Scale(3);
            Map(x => x.StarboardWell13, "sw13").Precision(8).Scale(3);
            Map(x => x.PortWell14, "pw14").Precision(8).Scale(3);
            Map(x => x.StarboardWell14, "sw14").Precision(8).Scale(3);
            Map(x => x.PortWell15, "pw15").Precision(8).Scale(3);
            Map(x => x.StarboardWell15, "sw15").Precision(8).Scale(3);
            Map(x => x.PortWell16, "pw16").Precision(8).Scale(3);
            Map(x => x.StarboardWell16, "sw16").Precision(8).Scale(3);
            Map(x => x.PortWell17, "pw17").Precision(8).Scale(3);
            Map(x => x.StarboardWell17, "sw17").Precision(8).Scale(3);
            Map(x => x.PortWell18, "pw18").Precision(8).Scale(3);
            Map(x => x.StarboardWell18, "sw18").Precision(8).Scale(3);
            Map(x => x.PortWell19, "pw19").Precision(8).Scale(3);
            Map(x => x.StarboardWell19, "sw19").Precision(8).Scale(3);
            Map(x => x.PortWell20, "pw20").Precision(8).Scale(3);
            Map(x => x.StarboardWell20, "sw20").Precision(8).Scale(3);
            Map(x => x.PortWell21, "pw21").Precision(8).Scale(3);
            Map(x => x.StarboardWell21, "sw21").Precision(8).Scale(3);
            Map(x => x.PortWell22, "pw22").Precision(8).Scale(3);
            Map(x => x.StarboardWell22, "sw22").Precision(8).Scale(3);
            Map(x => x.PortWell23, "pw23").Precision(8).Scale(3);
            Map(x => x.StarboardWell23, "sw23").Precision(8).Scale(3);
            Map(x => x.PortWell24, "pw24").Precision(8).Scale(3);
            Map(x => x.StarboardWell24, "sw24").Precision(8).Scale(3);
            // TODO Add Port/Starboard wells 1 through 23
            Map(x => x.ObserversTotal, "obs_total").Precision(8).Scale(3);
            Map(x => x.CumulativeTotal, "cum_total").Precision(8).Scale(3);
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");

            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
