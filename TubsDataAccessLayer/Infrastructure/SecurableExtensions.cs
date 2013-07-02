// -----------------------------------------------------------------------
// <copyright file="SecurableExtensions.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using NHibernate;

    /// <summary>
    /// Extension methods for working with ISecurable entities.
    /// </summary>
    public static class SecurableExtensions
    {
        public static bool AclContains(this ISecurable securable, string entityName)
        {
            return securable.AccessControlList.Where(ace => ace.EntityName == entityName).Count() > 0;
        }


        public static ISession FilterByAcl(this ISession session, string entityName)
        {
            if (null == session)
                return session;

            // If the session is already filtered, FIDO
            if (null != session.GetEnabledFilter(EntityNameFilter.FilterName))
                return session;

            session.EnableFilter(EntityNameFilter.FilterName).SetParameter(EntityNameFilter.ParamName, entityName);

            return session;
        }
        
        public static bool IsLoadableFor(this ISecurable securable, string entityName)
        {
            if (null == securable || String.IsNullOrEmpty(entityName))
                return false;

            // Case sensitive for now.  Once this works with LINQ, maybe we can muck with
            // getting it to be case insensitive
            return securable.AccessControlList.Where(ace => ace.EntityName == entityName).Count() > 0;
        }

        /// <summary>
        /// Presumably due to NHibernate proxy "magic", the C# 'is' operator isn't correctly identifying
        /// types which implement ISecurable.  This extension method uses a slightly more verbose method
        /// that has been shown to work.
        /// </summary>
        /// <param name="type">Type to be checked</param>
        /// <returns>true if incoming Type implements ISecurable, false otherwise.</returns>
        public static bool IsSecurable(this Type type)
        {
            // TODO:  Can this be replaced by typeof(ISecurable).IsAssignableFrom(type) ?
            if (null == type || null == type.GetInterfaces() || type.GetInterfaces().Count() == 0)
                return false;

            return type.GetInterfaces().Contains(typeof(ISecurable));
        }
    }
}
