using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EventExplorer.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Attendance> Attendances { get; set; } = new Collection<Attendance>();
    }
}
