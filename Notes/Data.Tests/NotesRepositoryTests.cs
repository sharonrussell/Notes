using Data.NHibernate;
using Notes;
using NUnit.Framework;

namespace Data.Tests
{
    [TestFixture]
    public class NotesRepositoryTests
    {
        private INotesRepository _notesRepository;

        private INHibernateHelper _nHibernateHelper;

        [SetUp]
        public void SetUp()
        {
            _nHibernateHelper = new TestNHibernateHelper();

            _notesRepository = new NotesRepository(_nHibernateHelper);
        }

        [Test]
        public void When_AddingNote_Should_SaveToDB()
        {
            _notesRepository.AddNote("test note");

            Note note;
            
            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    note = session.Get<Note>(1);
                    transaction.Commit();
                }
            }

            Assert.That(note, Is.Not.Null);
            Assert.That(note.Text, Is.EqualTo("test note"));
        }
    }
}
