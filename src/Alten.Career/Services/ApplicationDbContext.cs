using Alten.Career.Models;
using Microsoft.EntityFrameworkCore;

namespace Alten.Career.Services
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<JobApplicationAttachment> JobApplicationAttachments { get; set; }
    }
}
