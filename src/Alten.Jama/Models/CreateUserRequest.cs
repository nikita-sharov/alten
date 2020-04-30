using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    public sealed class CreateUserRequest
    {
        [Required]
        [StringLength(200)]
        [RegularExpression(Pattern.Username)]
        public string Username { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [Required]
        [StringLength(132)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(64)]
        public string Phone { get; set; }

        [StringLength(64)]
        public string Title { get; set; }

        [MaxLength(64)]
        public string Location { get; set; }

        public LicenseType LicenseType { get; set; }
    }
}
