using System;

namespace EventExplorer.Api.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumHeadCount { get; set; }
        public bool IsIndoor { get; set; }
        public bool NeedCovidCertificate { get; set; }
    }
}
