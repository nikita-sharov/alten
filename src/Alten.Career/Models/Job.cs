using System.ComponentModel.DataAnnotations;

namespace Alten.Career.Models
{
    public sealed class Job
    {
        internal const int TasksMaxLength = 1024;
        internal const int ProfileMaxLength = 1024;

        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        [Required]
        [MaxLength(64)]
        public string Location { get; set; }

        public ApplicationAreas ApplicationAreas { get; set; }

        public BusinessBranches BusinessBranches { get; set; }

        public EntryLevels EntryLevels { get; set; }

        [Required]
        [MaxLength(TasksMaxLength)]
        public string Tasks { get; set; }

        [Required]
        [MaxLength(ProfileMaxLength)]
        public string Profile { get; set; }

        public int MonthlySalaryInEuros { get; set; }

        public int ContactPersonId { get; set; }

        public Employee ContactPerson { get; set; }
    }
}
