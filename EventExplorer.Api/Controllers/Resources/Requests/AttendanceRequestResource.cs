using System.ComponentModel.DataAnnotations;

namespace EventExplorer.Api.Controllers.Resources.Requests
{
    public class AttendanceRequestResource
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int EventId { get; set; }
    }
}
