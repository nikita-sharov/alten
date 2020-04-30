using Alten.Career.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Alten.Career.ViewModels
{
    // TODO: Kick description
    ////[Description("Job description")]
    public class JobViewModel
    {
        private static readonly IFormatProvider SalaryFormatInfo = new NumberFormatInfo
        {
            NumberGroupSeparator = "."
        };

        ////[Display(Name = "Reference number")]
        public int ReferenceNumber { get; set; }

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

        ////[Display(Name = "Business branches")]
        public BusinessBranches BusinessBranches { get; set; }

        ////[Display(Name = "Entry levels")]
        public EntryLevels EntryLevels { get; set; }

        // TODO: Fix DataType.
        [DataType(DataType.MultilineText)]
        public ICollection<string> Tasks { get; set; }

        // TODO: Fix DataType.
        [DataType(DataType.MultilineText)]
        public ICollection<string> Profile { get; set; }

        /// <summary>
        /// Lower inclusive bound of the salary range, gross, in euros.
        /// </summary>
        public int MonthlySalaryInEuros { get; set; }        

        public string SalaryText => $"Salary from {MonthlySalaryText} gross per month on basis 38,5 h/week with the explicit willingness to overpay depending on qualification and experience.";

        [Display(Name = "Your contact person")]
        public EmployeeViewModel ContactPerson { get; set; }

        public string Footer { get; set; } = "Are you looking for interesting tasks and a permanent employment contract? Then apply now using our online application form.";

        private string MonthlySalaryText => string.Format(SalaryFormatInfo, "{0:#,###},-- €", MonthlySalaryInEuros);
    }
}
