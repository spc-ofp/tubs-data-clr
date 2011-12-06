// -----------------------------------------------------------------------
// <copyright file="TubsDataService.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using Spc.Ofp.Tubs.DAL.Entities;
    using System.Reflection;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TubsDataService
    {
        public static ISessionFactory CreateSessionFactory(string server, string database)
        {
            IPersistenceConfigurer cfg =
                MsSqlConfiguration.MsSql2008.ConnectionString(
                    c => c
                        .Server(server)
                        .Database(database)
                        .TrustedConnection()
                );

            //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Observer>())
            return Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
