using System.Collections.Generic;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface INotesService
    {
        [OperationContract]
        void AddNote(string text);

        [OperationContract]
        NoteDto GetNote(int id);

        IEnumerable<NoteDto> GetAllNotes();
    }
}
