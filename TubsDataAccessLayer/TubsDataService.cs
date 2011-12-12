﻿// -----------------------------------------------------------------------
// <copyright file="TubsDataService.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
[assembly: System.CLSCompliant(true)]
namespace Spc.Ofp.Tubs.DAL
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
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TubsDataService
    {
        /// <summary>
        /// Prevents a default instance of the TubsDataService class from being created.
        /// </summary>
        private TubsDataService()
        { 
        }
        
        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                return sessionFactory ?? (sessionFactory = CreateSessionFactory());
            }
        }

        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void Dispose()
        {
            SessionFactory.Close();
        }
        
        private static ISessionFactory CreateSessionFactory()
        {
            IPersistenceConfigurer cfg =
                MsSqlConfiguration.MsSql2008.ConnectionString(
                    c => c
                        .FromConnectionStringWithKey("TUBS"));
            
            return Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
