namespace JobSeekerAPI.Models
{
    public class HR : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;

        public int UserId { get; set; }
        public int CompanyId { get; set; }

        public User User { get; set; }
        public Company Company { get; set; }
        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    }
}
