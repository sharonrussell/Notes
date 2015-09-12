using System.Collections.Generic;
using Notes;

namespace Data
{
    public interface INotesRepository
    {
        void AddNote(string text);

        Note GetNote(int id);

        IEnumerable<Note> GetAllNotes();

        void DeleteNote(int id);
    }
}