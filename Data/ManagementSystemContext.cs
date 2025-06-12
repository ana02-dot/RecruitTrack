using JobSeekerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerAPI.Data
{
    public class ManagementSystemContext : DbContext
    { 
    public ManagementSystemContext(DbContextOptions<ManagementSystemContext> options)
        : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<HR> HRs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User ↔ HR (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.HRProfile)
                .WithOne(hr => hr.User)
                .HasForeignKey<HR>(hr => hr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User ↔ Applicant (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.ApplicantProfile)
                .WithOne(a => a.User)
                .HasForeignKey<Applicant>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // HR ↔ Company (Many HRs to One Company)
            modelBuilder.Entity<HR>()
                .HasOne(hr => hr.Company)
                .WithMany(c => c.HRs)
                .HasForeignKey(hr => hr.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // HR ↔ JobPosting (One HR to Many Postings)
            modelBuilder.Entity<JobPosting>()
                .HasOne(j => j.HR)
                .WithMany(hr => hr.JobPostings)
                .HasForeignKey(j => j.HRId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobApplication>()
                .HasKey(ja => ja.Id); //PK

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Applicant)
                .WithMany(a => a.JobApplications)
                .HasForeignKey(ja => ja.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobPosting)
                .WithMany(jp => jp.JobApplications)
                .HasForeignKey(ja => ja.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
