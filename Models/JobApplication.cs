namespace JobSeekerAPI.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected
    }

}
