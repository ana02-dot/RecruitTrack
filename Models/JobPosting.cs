namespace JobSeekerAPI.Models
{
    public class JobPosting
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public decimal? Salary { get; set; }

        public int HRId { get; set; }
        public HR HR { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    }
}