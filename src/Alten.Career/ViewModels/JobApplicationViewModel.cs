using Alten.Career.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alten.Career.ViewModels
{
    public sealed class JobApplicationViewModel
    {


        public JobViewModel Job { get; set; }

        [Display(Description = "Only for addressing properly and personally.")]
        public Salutation Salutation { get; set; }

        [StringLength(32)]
        [Display(Name = "Title")]
        public string AcademicTitle { get; set; }

        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Display(Name = "Nationality")]
        public string Citizenship { get; set; }

        [Required]
        [StringLength(128)]
        public string Address { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Zip")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "Place")]
        public string Location { get; set; }

        [Display(Description = "Only for differentiating applicants.")]
        [DisplayFormat(DataFormatString = "DD.MM.YYYY")]
        public DateTime? DateOfBirth { get; set; }

        [Required]        
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        [DataType(DataType.PhoneNumber)]        
        [Display(Name = "Telephone")]
        public string PrimaryPhone { get; set; }

        [StringLength(32)]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public string SecondaryPhone { get; set; }

        [Display(Name = "Starting date*")]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Salary requirement in € per year")]
        public int? YearlySalaryInEuros { get; set; }

        [Display(Name = "Are you registered for job search by Public Employment Service Austria (AMS)?")]
        public bool? RegisteredAsUnemployed { get; set; }

        [StringLength(1024)]
        [Display(
            Name = "Short letter/Comments",
            Description = "(e.g. job assignment, place of work, mobility, part-time)",
            Prompt = "Please note down any comments to your applications or use this textbox for a short letter if it is not part of your application documents anyway.")]
        public string ShortLetter { get; set; }

        [Required]
        [Display(
            Name = "Upload application",
            Description = "Please upload your application documents below[_](CVs, certificates, other documents), preferably in DOC, DOCX, PDF, PNG, JPEG or JPG. Make sure that each file is not larger than 4[_]MB.",
            Prompt = "Choose file")]
        public ICollection<JobApplicationAttachment> Attachments { get; set; }

        [Display(Name = "I accept the privacy note.")]
        public bool PrivacyNoteAccepted { get; set; }

        public static JobApplicationViewModel Create(JobApplication source) =>
            new JobApplicationViewModel
            {
                AcademicTitle = source.AcademicTitle,
                Address = source.Address,
                Attachments = source.Attachments,
                Citizenship = source.Citizenship,
                DateOfBirth = source.DateOfBirth,
                Email = source.Email,
                FirstName = source.FirstName,
                Job = JobViewModel.Create(source.Job),
                LastName = source.LastName,
                Location = source.Location,
                PostalCode = source.PostalCode,
                PrimaryPhone = source.PrimaryPhone,
                PrivacyNoteAccepted = true,
                RegisteredAsUnemployed = source.RegisteredAsUnemployed,
                Salutation = source.Salutation,
                SecondaryPhone = source.SecondaryPhone,
                ShortLetter = source.ShortLetter,
                StartingDate = source.StartingDate,
                YearlySalaryInEuros = source.YearlySalaryInEuros
            };
    }
}
