using System;
using System.ComponentModel.DataAnnotations;

namespace EventExplorer.Api.Controllers.Resources.Requests
{
    public class CreateUserRequestResource
    {
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
