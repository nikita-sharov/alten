using JamaClient.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamaClient.Models
{
    public sealed class UpdateUserRequest : UserRequest
    {
        [NotEmptyOrWhitespace]
        [StringLength(200)]
        [RegularExpression(Pattern.Username)]
        public string Username { get; set; }

        [NotEmptyOrWhitespace]
        [StringLength(200, MinimumLength = 6)]
        public string Password { get; set; }

        [NotEmptyOrWhitespace]
        [StringLength(200)]
        public string FirstName { get; set; }

        [NotEmptyOrWhitespace]
        [StringLength(200)]
        public string LastName { get; set; }

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
