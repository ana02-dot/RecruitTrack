namespace JobSeekerAPI.Models
{
    public class JobApplication : BaseEntity
    {
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // Pending, UnderReview, Accepted, Rejected
        public int ApplicantId { get; set; }
        public int JobPostingId { get; set; }

        public Applicant Applicant { get; set; } = null!;
        public JobPosting JobPosting { get; set; } = null!;

        
        public bool IsPending => Status.ToLower() == "Pending";
        public bool IsAccepted => Status.ToLower() == "Accepted";
        public bool IsRejected => Status.ToLower() == "Rejected";
        public bool IsUnderReview => Status.ToLower() == "UnderReview";
    }

}
