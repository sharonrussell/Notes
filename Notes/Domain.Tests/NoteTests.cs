using Notes;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class NoteTests
    {
        [Test]
        public void When_CreatingNote_Should_SetTitle()
        {
            Note note = new Note {Text = "some text"};

            Assert.That(note.Text, Is.EqualTo("some text"));
        }
    }
}
