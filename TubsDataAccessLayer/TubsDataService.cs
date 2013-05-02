// -----------------------------------------------------------------------
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
    using System.Collections;
    using System.Linq;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using Spc.Ofp.Tubs.DAL.Entities;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

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

        public static IRepository<T> GetRepository<T>(bool stateless) where T : class
        {
            if (stateless)
                return new Repository<IStatelessSession, T>(GetStatelessSession());
            return new Repository<ISession, T>(GetSession());
        }

        public static IRepository<T> GetRepository<T>(IStatelessSession session) where T : class
        {
            return new Repository<IStatelessSession, T>(session);
        }

        public static IRepository<T> GetRepository<T>(ISession session) where T : class
        {
            return new Repository<ISession, T>(session);
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

                // 
                trip.Electronics.ToList().ForEach(x =>
                {
                    //System.Console.WriteLine("Saving {0}: {1}", x.Make, x.Model);
                    session.Save(x); 
                });

                trip.Interactions.ToList().ForEach(x =>
                {
                    session.Save(x);
                    if (x is GearInteraction)
                    {
                        ((GearInteraction)x).Details.ToList().ForEach(y => session.Save(y));
                    }
                    //x.Details.ToList().ForEach(y => session.Save(y));
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
                if (typeof(LongLineTrip) == trip.GetType())
                {
                    var lltrip = trip as LongLineTrip;
                    foreach (var fset in lltrip.FishingSets)
                    {
                        session.Save(fset);
                        fset.CatchList.ToList().ForEach(x => session.Save(x));
                        fset.EventList.ToList().ForEach(x => session.Save(x));
                        fset.ConversionFactors.ToList().ForEach(x => session.Save(x));
                    }
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
            using (IStatelessSession session = GetStatelessSession())
            {
                return Execute(session, sql, list);
            }
        }

        public static IList Execute(IStatelessSession session, string sql, params object[] list)
        {
            var query = session.CreateSQLQuery(sql);
            for (int i = 0; i < list.Length; i++)
            {
                query.SetParameter(i, list[i]);
            }
            return query.List();
        }

        public static IQueryable<Trip> Search(IStatelessSession session, SearchCriteria criteria)
        {
            if (null == criteria || !criteria.IsValid())
            {
                return Enumerable.Empty<Trip>().AsQueryable();
            }
            var predicate = criteria.AsPredicate();
            return new Repository<IStatelessSession, Trip>(session).FilterBy(predicate);
        }

        // TripHeader version returns a lighter entity.  The trade-off is that the search criteria aren't
        // as flexible:  Only codes are searched for observer and port.
        public static IQueryable<TripHeader> SearchHeaders(IStatelessSession session, SearchCriteria criteria)
        {
            if (null == criteria || !criteria.IsValid())
            {
                return Enumerable.Empty<TripHeader>().AsQueryable();
            }
            var predicate = criteria.AsHeaderPredicate();
            return new Repository<IStatelessSession, TripHeader>(session).FilterBy(predicate);
        }


        public static IQueryable<Trip> Search(ISession session, SearchCriteria criteria)
        {
            if (null == criteria || !criteria.IsValid())
            {
                return Enumerable.Empty<Trip>().AsQueryable();
            }
            var predicate = criteria.AsPredicate();
            return new Repository<ISession, Trip>(session).FilterBy(predicate);
        }

        public static IQueryable<TripHeader> SearchHeaders(ISession session, SearchCriteria criteria)
        {
            if (null == criteria || !criteria.IsValid())
            {
                return Enumerable.Empty<TripHeader>().AsQueryable();
            }
            var predicate = criteria.AsHeaderPredicate();
            return new Repository<ISession, TripHeader>(session).FilterBy(predicate);
        }

        // TODO Work out how to eagerly load all the entities for a trip via QueryOver/Fetch/ThenFetch

        // TODO Work out how to do this in a more portable fashion...
        private static ISessionFactory CreateSessionFactoryEx()
        {
            IPersistenceConfigurer cfg =
                PostgreSQLConfiguration.Standard.ConnectionString(
                    c => c.FromConnectionStringWithKey("TUBS"))
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