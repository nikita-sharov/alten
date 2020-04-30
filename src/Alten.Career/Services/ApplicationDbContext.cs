using Alten.Career.Models;
using Microsoft.EntityFrameworkCore;

namespace Alten.Career.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<JobApplicationAttachment> JobApplicationAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////modelBuilder.Entity<JobApplicationViewModel>().HasKey(a => new { a.JobId, a.Id });
        }
    }
}
