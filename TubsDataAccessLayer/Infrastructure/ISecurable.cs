/// -----------------------------------------------------------------------
// <copyright file="ISecurable.cs" company="Secretariat of the Pacific Community">
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
    
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ISecurable is a marker interface to denote entities that have
    /// a view ACL.
    /// </summary>
    public interface ISecurable
    {
        bool IsAllowed(string entityName);

        IEnumerable<IAccessControl> AccessControlList
        {
            get;
        }
    }
}
