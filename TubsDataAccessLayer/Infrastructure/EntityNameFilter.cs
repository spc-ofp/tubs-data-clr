// -----------------------------------------------------------------------
// <copyright file="EntityNameFilter.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// So close and yet so far:
    /// http://stackoverflow.com/questions/5131004/fluent-nhibernate-and-filtering-one-to-many-relationship-on-query-requiring-mult
    /// http://stackoverflow.com/questions/960625/syntax-to-define-a-nhibernate-filter-with-fluent-nhibernate
    /// Session filters don't work with a joined entity (e.g. separate ACL table)
    /// Still, StackOverflow answer is useful for simple filtering directly on entities.
    /// NHForge filter article
    /// http://nhforge.org/wikis/reference2-0en/chapter-15-filtering-data.aspx
    /// For current version of NHibernate (3.3), filter can only be applied to standard session, not
    /// stateless session.
    /// 
    /// Here's another article on filters.  Maybe there's some more 'magic' that can happen in a Filter that I'm not
    /// savvy to yet.
    /// http://nhforge.org/wikis/howtonh/contextual-data-using-nhibernate-filters.aspx
    /// </summary>
    public sealed class EntityNameFilter : FilterDefinition
    {
        public const string FilterName = "EntityNameFilter";
        public const string ParamName = "EntityName";
        
        public EntityNameFilter()
        {
            WithName(FilterName)
                .WithCondition("EntityName = :EntityName")
                .AddParameter(ParamName, NHibernate.NHibernateUtil.String);
        }
    }
}
