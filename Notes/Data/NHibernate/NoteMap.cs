using FluentNHibernate.Mapping;
using Notes;

namespace Data.NHibernate
{
    public class NoteMap : ClassMap<Note>
    {
        public NoteMap()
        {
            Map(n => n.Text);

            Id(n => n.Id).GeneratedBy.Increment();
        }
    }
}
