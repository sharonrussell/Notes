using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Data.NHibernate
{
    public class TestNHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private readonly string _connectionString;

        public TestNHibernateHelper()
        {
            _connectionString = @"Server=(localdb)\mssqllocaldb; Integrated Security=True; Initial Catalog=NotesTest";
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
                .ExposeConfiguration(config => new SchemaExport(config).Execute(true, true, false))
                .BuildSessionFactory();
        }
    }
}