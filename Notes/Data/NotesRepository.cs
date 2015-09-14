using System.Collections.Generic;
using System.Linq;
using Data.NHibernate;
using NHibernate.Linq;
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

        public Note GetNote(int id)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var note = session.Get<Note>(id);

                    transaction.Commit();
                    return note;
                }
            }
        }

        public IEnumerable<Note> GetAllNotes()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var notes = session.Query<Note>().ToList();
                    transaction.Commit();

                    return notes;
                }
            }
        }

        public void DeleteNote(int id)
        {
            var note = GetNote(id);

            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(note);
                    transaction.Commit();
                }
            }
        }

        public void EditNote(int id, string text)
        {
            var note = GetNote(id);
            note.Text = text;

            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(note);
                    transaction.Commit();
                }
            }
        }
    }
}