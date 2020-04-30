using System.ComponentModel.DataAnnotations;

namespace Alten.Career.Models
{
    public sealed class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(64)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(64)]
        public string Phone { get; set; }
    }
}
