using System.ComponentModel.DataAnnotations;

namespace EventExplorer.Api.Controllers.Resources.Requests
{
    public class CreateOrganizerRequestResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
