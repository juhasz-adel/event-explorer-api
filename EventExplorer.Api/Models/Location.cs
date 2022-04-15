using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EventExplorer.Api.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int MaximumHeadCount { get; set; }
        public ICollection<Event> Events { get; set; } = new Collection<Event>();
    }
}
