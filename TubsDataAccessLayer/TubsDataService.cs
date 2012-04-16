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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// FIXME:  Add localization
    /// http://www.hanselman.com/blog/GlobalizationInternationalizationAndLocalizationInASPNETMVC3JavaScriptAndJQueryPart1.aspx
    /// </summary>
    public sealed class TubsDataService
    {
        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                return sessionFactory ?? (sessionFactory = CreateSessionFactory());
            }
        }

        public static IStatelessSession GetStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }

        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void Dispose()
        {
            SessionFactory.Close();
        }

        public static bool SaveFullTrip(Trip trip)
        {
            using (var session = GetSession())
            using (var xa = session.BeginTransaction())
            {
                // Save the trip first
                session.Save(trip);
                // Save the listed entities
                trip.PollutionEvents.ToList().ForEach(x =>
                {
                    session.Save(x);
                    x.Details.ToList().ForEach(y => session.Save(y));
                });
                trip.Electronics.ToList().ForEach(x => session.Save(x));
                trip.Interactions.ToList().ForEach(x =>
                {
                    session.Save(x);
                    x.Details.ToList().ForEach(y => session.Save(y));
                });

                trip.Sightings.ToList().ForEach(x => session.Save(x));
                trip.Transfers.ToList().ForEach(x => session.Save(x));
                if (typeof(PurseSeineTrip) == trip.GetType())
                {
                    var pstrip = trip as PurseSeineTrip;
                    pstrip.Crew.ToList().ForEach(x => session.Save(x));
                    foreach (var day in pstrip.SeaDays)
                    {
                        session.Save(day);
                        day.Activities.ToList().ForEach(x =>
                        {
                            session.Save(x);
                            if (null != x.FishingSet)
                            {
                                session.Save(x.FishingSet);
                                x.FishingSet.CatchList.ToList().ForEach(y => session.Save(y));
                                x.FishingSet.SamplingHeaders.ToList().ForEach(y =>
                                {
                                    session.Save(y);
                                    y.Samples.ToList().ForEach(z => session.Save(z));
                                    y.Brails.ToList().ForEach(z => session.Save(z));
                                });
                            }

                        });

                    }

                    pstrip.WellContent.ToList().ForEach(x => session.Save(x));
                    pstrip.WellReconciliations.ToList().ForEach(x => session.Save(x));
                }
                xa.Commit();
            }
            return true;
        }

        /// <summary>
        /// Execute will execute an arbitrary SQL statement using the specified parameter
        /// list as ordered (not named!) parameters.
        /// ORMs are great as far as they're great, but sometimes one needs a little more flexibility.
        /// Having said that, this is a very dangerous method as it requires the caller to pass ANSI
        /// SQL or at least budget for fixing issues when moving to a new database.
        /// </summary>
        /// <param name="sql">SQL query to be executed</param>
        /// <param name="list">Parameter list.  Can be omitted</param>
        /// <returns>Results of SQL query as List of objects.  
        /// If the query has a single column, the contained object will be strongly typed.
        /// Otherwise, the contained object is an object[] and value extraction is the callers responsibility.</returns>
        public static IList Execute(string sql, params object[] list)
        {
            using (ISession session = GetSession())
            {
                return Execute(session, sql, list);
            }
        }

        public static IList Execute(ISession session, string sql, params object[] list)
        {
            var query = session.CreateSQLQuery(sql);
            for (int i = 0; i < list.Length; i++)
            {
                query.SetParameter(i, list[i]);
            }
            return query.List();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            IPersistenceConfigurer cfg =
                MsSqlConfiguration.MsSql2008.ConnectionString(
                    c => c
                        .FromConnectionStringWithKey("TUBS"))
                // Uncomment later after testing
                //.QuerySubstitutions("true 1, false 0, True 1, False 0, yes 'Y', no 'N', bw_or ^, bw_and &, bw_not ~")
#if DEBUG
                .ShowSql()
#endif
                ;

            return Fluently.Configure()
                .Database(cfg)
                .Mappings(m => 
                {
                    m.FluentMappings
                        .AddFromAssemblyOf<TubsDataService>()
#if DEBUG
                        .ExportTo(@"C:\temp\mappings")
#endif
                        ;                   
                })
                .BuildSessionFactory();
        }
    }
}