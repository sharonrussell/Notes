using NHibernate;

namespace Data.NHibernate
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}