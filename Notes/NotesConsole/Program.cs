using Data.NHibernate;
using Notes;

namespace NotesConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var note = new Note {Text = "some text", Id = 1};

                    session.Save(note);
                    transaction.Commit();
                }

                using (var transaction = session.BeginTransaction())
                {
                    var note = session.Get<Note>(1);
                }
            }
        }
    }
}
