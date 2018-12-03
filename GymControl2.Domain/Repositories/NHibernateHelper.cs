using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GymControl2.Domain.Domain;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace GymControl2.Domain.Repositories
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MySQLConfiguration.Standard
                        .ConnectionString("Server=localhost;Database=gymsys;Uid=root;Pwd=;")
                        .ShowSql()
                        )
                        .Mappings(m => m
                            .FluentMappings
                                .AddFromAssemblyOf<User>()
                                .AddFromAssemblyOf<Rol>())
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void DeleteDB()
        {
            _sessionFactory = null;
        }

    }
}
