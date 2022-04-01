using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EventExplorer.Api.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int EntranceFee { get; set; }
        public bool IsIndoor { get; set; }
        public ICollection<Attendance> Attendances { get; set; } = new Collection<Attendance>();
    }
}
