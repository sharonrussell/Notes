using System.Collections.Generic;
using System.Linq;
using Data;

namespace Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;

        public NotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public NotesService()
        {
        }

        public void AddNote(string text)
        {
            _notesRepository.AddNote(text);
        }

        public NoteDto GetNote(int id)
        {
            var note = _notesRepository.GetNote(id);

            var noteDto = new NoteDto
            {
                Text = note.Text,
                Id = note.Id
            };

            return noteDto;
        }

        public IEnumerable<NoteDto> GetAllNotes()
        {
            var notes = _notesRepository.GetAllNotes();

            var noteDtos = notes.Select(note => new NoteDto
            {
                Text = note.Text,
                Id = note.Id
            }).ToList();

            return noteDtos;
        }
    }
}