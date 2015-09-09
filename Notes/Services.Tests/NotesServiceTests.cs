using Data;
using Moq;
using Notes;
using NUnit.Framework;

namespace Services.Tests
{
    [TestFixture]
    public class NotesServiceTests
    {
        private INotesService _notesService;

        private Mock<INotesRepository> _notesRepository; 

        [SetUp]
        public void SetUp()
        {
            _notesRepository = new Mock<INotesRepository>();
            _notesService = new NotesService(_notesRepository.Object);
        }

        [Test]
        public void When_AddingNote_Should_AddToRepository()
        {
            _notesService.AddNote("text");

            _notesRepository.Verify(o => o.AddNote("text"), Times.Once);
        }

        [Test]
        public void When_GettingNote_Should_GetFromRepository()
        {
            _notesRepository.Setup(o => o.GetNote(It.IsAny<int>())).Returns(new Note
            {
                Text = "some text",
                Id = 1
            });

            NoteDto note = _notesService.GetNote(It.IsAny<int>());

            Assert.That(note, Is.Not.Null);
            Assert.That(note.Text, Is.EqualTo("some text"));
            Assert.That(note.Id, Is.EqualTo(1));
        }
    }
}
