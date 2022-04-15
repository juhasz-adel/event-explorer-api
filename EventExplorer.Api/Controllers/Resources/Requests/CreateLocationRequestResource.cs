using System.ComponentModel.DataAnnotations;

namespace EventExplorer.Api.Controllers.Resources.Requests
{
    public class CreateLocationRequestResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(4)]
        public string ZipCode { get; set; }

        [Required]
        public int MaximumHeadCount { get; set; }
    }
}
