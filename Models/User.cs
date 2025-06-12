namespace JobSeekerAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // hr, admin, applicant

        public Applicant? ApplicantProfile { get; set; }
        public HR? HRProfile { get; set; }
    }
}