using Alten.Career.Models;
using System.ComponentModel.DataAnnotations;

namespace Alten.Career.ViewModels
{
    public sealed class EmployeeViewModel
    {
        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [StringLength(64)]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(32)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public static EmployeeViewModel Create(Employee source) =>
            new EmployeeViewModel
            {
                Email = source.Email,
                FirstName = source.FirstName,
                JobTitle = source.JobTitle,
                LastName = source.LastName,
                Phone = source.Phone
            };
    }
}
