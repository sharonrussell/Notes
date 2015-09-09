using System.Runtime.Serialization;

namespace Services
{
    [DataContract]
    public class NoteDto
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public int Id { get; set; }
    }
}