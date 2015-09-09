using Data.NHibernate;
using Notes;

namespace NotesConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NHibernateHelper nHibernateHelper = new NHibernateHelper();

            using (var session = nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var note = new Note {Text = "some text"};

                    session.Save(note);
                    transaction.Commit();
                }

                using (var transaction = session.BeginTransaction())
                {
                    var note = session.Get<Note>(1);
                    transaction.Commit();
                }
            }
        }
    }
}
