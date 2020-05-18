using Alten.Career.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Alten.Career.ViewModels
{
    public class JobViewModel : IValidatableObject
    {
        private static readonly IFormatProvider SalaryFormatInfo = new NumberFormatInfo
        {
            NumberGroupSeparator = "."
        };

        [Display(Name = "Reference number")]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Header { get; set; } = "Looking for an exciting and permanent job offering a wide variety of different assignments? As a member of an interdisciplinary team, you will work on future-orientated projects in various high-tech sectors. Support our team as";

        [Required]
        [StringLength(32)]
        public string Title { get; set; }

        [Required]
        [StringLength(32)]
        public string Location { get; set; }

        [Display(Name = "Areas of application")]
        public ApplicationAreas ApplicationAreas { get; set; }

        public BusinessBranches BusinessBranches { get; set; }

        public EntryLevels EntryLevels { get; set; }

        public ICollection<string> Tasks { get; set; }

        public ICollection<string> Profile { get; set; }

        /// <summary>
        /// Lower inclusive bound of the salary range, gross, in euros.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int MonthlySalaryInEuros { get; set; }        

        public string SalaryText => $"Salary from {MonthlySalaryText} gross per month on basis 38,5 h/week with the explicit willingness to overpay depending on qualification and experience.";

        [Display(Name = "Your contact person")]
        public EmployeeViewModel ContactPerson { get; set; }

        public string Footer { get; set; } = "Are you looking for interesting tasks and a permanent employment contract? Then apply now using our online application form.";

        private string MonthlySalaryText => string.Format(SalaryFormatInfo, "{0:#,###},-- €", MonthlySalaryInEuros);

        public static JobViewModel Create(Job source) =>
            new JobViewModel
            {
                ApplicationAreas = source.ApplicationAreas,
                BusinessBranches = source.BusinessBranches,
                ContactPerson = EmployeeViewModel.Create(source.ContactPerson),
                EntryLevels = source.EntryLevels,
                Id = source.Id,
                Location = source.Location,
                MonthlySalaryInEuros = source.MonthlySalaryInEuros,
                Profile = source.Profile.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList(),
                Tasks = source.Tasks.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList(),
                Title = source.Title
            };

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const string FormatString = "{0} must not be longer than {1} characters.";

            var tasks = string.Join(Environment.NewLine, Tasks);
            if (tasks.Length > Job.TasksMaxLength)
            {
                yield return new ValidationResult(
                    string.Format(CultureInfo.InvariantCulture, FormatString, nameof(Tasks), Job.TasksMaxLength),
                    new[] { nameof(Tasks) });
            }

            var profile = string.Join(Environment.NewLine, Profile);
            if (profile.Length > Job.ProfileMaxLength)
            {
                yield return new ValidationResult(
                    string.Format(CultureInfo.InvariantCulture, FormatString, nameof(Profile), Job.ProfileMaxLength),
                    new[] { nameof(Profile) });
            }
        }
    }
}
