using System;
using System.ComponentModel.DataAnnotations;

namespace EventExplorer.Api.Controllers.Resources.Requests
{
    public class CreateEventRequestResource
    {
        [Required]
        public int OrganizerId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int EntranceFee { get; set; }

        [Required]
        public bool IsIndoor { get; set; }
    }
}
