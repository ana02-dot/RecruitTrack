namespace JobSeekerAPI.Models
{
    public class Applicant : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string Resume { get; set; } = string.Empty; // URL or path to the resume file
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
