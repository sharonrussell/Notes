using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Data.NHibernate
{
    public class NHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private readonly string _connectionString;

        public NHibernateHelper()
        {
            _connectionString = @"Server=(localdb)\mssqllocaldb; Integrated Security=True; Initial Catalog=Notes";
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    InitializeSessionFactory();
                }

                return _sessionFactory;
            }
        }

        private void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NoteMap>())
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(true, true))
                .BuildSessionFactory();
        }
    }
}
