using Data;
using Data.NHibernate;
using Ninject.Modules;

namespace Services
{
    public class NotesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INotesRepository>().To<NotesRepository>();
            Bind<INotesService>().To<NotesService>();
            Bind<INHibernateHelper>().To<NHibernateHelper>();
        }
    }
}
