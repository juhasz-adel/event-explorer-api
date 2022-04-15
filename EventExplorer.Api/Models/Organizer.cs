using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EventExplorer.Api.Models
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; } = new Collection<Event>();
    }
}
