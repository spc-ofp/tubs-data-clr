// -----------------------------------------------------------------------
// <copyright file="ProgramCodeFilter.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
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

    /// <summary>
    /// Simple session filter based on program code.
    /// </summary>
    /// <remarks>
    /// This session filter doesn't meet all requirements for
    /// user security.  It won't help if a user requests an entity
    /// within a trip directly by primary key.
    /// </remarks>
    public class ProgramCodeFilter : FilterDefinition
    {
        /// <summary>
        /// Using a constant value for the filter name makes configuration easier.
        /// </summary>
        public const string FilterName = "ProgramCodeFilter";

        /// <summary>
        /// Using a constant value for the filter parameter makes configuration easier.
        /// </summary>
        public const string ParamName = "ProgramCode";

        public ProgramCodeFilter()
        {
            WithName(FilterName)
                .WithCondition("obsprg_code = :ProgramCode")
                .AddParameter(ParamName, NHibernate.NHibernateUtil.String);
        }
    }
}
