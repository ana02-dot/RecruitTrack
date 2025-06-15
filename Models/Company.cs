namespace JobSeekerAPI.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Description { get; set; }

        public ICollection<HR> HRs { get; set; }
        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    }
}