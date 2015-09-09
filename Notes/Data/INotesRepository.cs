using Notes;

namespace Data
{
    public interface INotesRepository
    {
        void AddNote(string text);

        Note GetNote(int id);
    }
}