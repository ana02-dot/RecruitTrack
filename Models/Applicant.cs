namespace JobSeekerAPI.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string Resume { get; set; } = string.Empty; // URL or path to the resume file
        public int UserId { get; set; } // Foreign key to User entity
        public User User { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
