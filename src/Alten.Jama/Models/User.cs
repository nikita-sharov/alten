using System;
using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string LastName { get; set; }

        [MaxLength(132)]
        public string Email { get; set; }

        [MaxLength(64)]
        public string Phone { get; set; }

        [MaxLength(64)]
        public string Title { get; set; }

        [MaxLength(64)]
        public string Location { get; set; }

        public LicenseType LicenseType { get; set; }

        // Always null (also when set via web application)
        public string AvatarUrl { get; set; }

        public bool Active { get; set; }
    }
}
