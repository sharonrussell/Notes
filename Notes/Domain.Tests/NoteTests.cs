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
            Note note = new Note("some text");

            Assert.That(note.GetText(), Is.EqualTo("some text"));
        }
    }
}
