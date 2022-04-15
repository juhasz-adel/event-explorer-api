using System;

namespace EventExplorer.Api.Controllers.Resources.Responses
{
    public class EventResponseResource
    {
        public int Id { get; set; }
        public OrganizerResponseResource Organizer { get; set; }
        public CategoryResponseResource Category { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LocationResponseResource Location { get; set; }
        public int EntranceFee { get; set; }
        public bool IsIndoor { get; set; }
    }
}
