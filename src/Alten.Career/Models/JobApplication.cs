using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alten.Career.Models
{
    public sealed class JobApplication
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }

        public Salutation Salutation { get; set; }

        [MaxLength(32)]
        public string AcademicTitle { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        public string Citizenship { get; set; }

        [Required]
        [MaxLength(128)]
        public string Address { get; set; }

        [Required]
        [MaxLength(8)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(64)]
        public string Location { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(64)]
        public string Email { get; set; }

        [Required]
        [MaxLength(32)]
        public string PrimaryPhone { get; set; }

        [MaxLength(32)]
        public string SecondaryPhone { get; set; }

        public DateTime StartingDate { get; set; }

        public int? YearlySalaryInEuros { get; set; }

        public bool? RegisteredAsUnemployed { get; set; }

        [MaxLength(1024)]
        public string ShortLetter { get; set; }

        public ICollection<JobApplicationAttachment> Attachments { get; set; }
    }
}
