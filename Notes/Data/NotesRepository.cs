using Data.NHibernate;
using Notes;

namespace Data
{
    public class NotesRepository : INotesRepository
    {
        private readonly INHibernateHelper _nHibernateHelper;

        public NotesRepository(INHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public void AddNote(string text)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var note = new Note {Text = text};
                    session.Save(note);

                    transaction.Commit();
                }
            }
        }
    }
}