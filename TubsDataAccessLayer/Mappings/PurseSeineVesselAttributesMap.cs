// -----------------------------------------------------------------------
// <copyright file="PurseSeineVesselAttributesMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the PurseSeineVesselAttributes entity.
    /// </summary>
    public class PurseSeineVesselAttributesMap : ClassMap<PurseSeineVesselAttributes>
    {
        public PurseSeineVesselAttributesMap()
        {
            Schema("obsv");
            Table("s_vess_attrib");
            Id(x => x.Id, "s_vess_attrib_id").GeneratedBy.Identity();
            Map(x => x.SpeedboatCount, "speedboats_n");
            Map(x => x.TowboatCount, "tow_n");
            Map(x => x.AuxiliaryBoatCount, "auxboats_n");
            Map(x => x.LightCount, "light_n");
            Map(x => x.HasTenderBoats, "tenderboats_yn");
            Map(x => x.SkiffMake, "skiff_make");
            Map(x => x.SkiffPower, "skiff_hp");
            Map(x => x.CruiseSpeed, "cruise_speed");
            Map(x => x.HelicopterMake, "heli_make").Length(15);
            Map(x => x.HelicopterModel, "heli_model").Length(15);
            Map(x => x.HelicopterRegistrationNumber, "heli_reg_no").Length(15);
            Map(x => x.HelicopterRangeUnit, "heli_range_unit4_id").CustomType<UnitOfMeasure>();
            Map(x => x.HelicopterColor, "heli_colour").Length(30);
            Map(x => x.HelicopterServiceOtherCount, "heli_services_n");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");
            References(x => x.Trip).Column("obstrip_id");
        }
    }
}
