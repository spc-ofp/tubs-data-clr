// -----------------------------------------------------------------------
// <copyright file="Gen5MaterialMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the Gen5Material entity.
    /// </summary>
    public sealed class Gen5MaterialMap : ClassMap<Gen5Material>
    {
        public Gen5MaterialMap()
        {
            Schema("obsv");
            Table("gen5fadmaterial");
            Id(x => x.Id, "material_id");
            Map(x => x.Material, "material_code").CustomType<FadMaterials>();
            Map(x => x.IsAttachment, "is_attachment").CustomType<YesNoType>();

            References(x => x.Fad).Column("fad_id").ForeignKey("FK_gen5fad_material");
        }
    }
}
