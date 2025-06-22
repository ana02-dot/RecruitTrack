using JobSeekerAPI.Models;

namespace JobSeekerAPI.Services;

public interface IApplicantService
{
    Task<IEnumerable<Applicant>> GetAllApplicantAsync();
    Task<Applicant?> GetApplicantByIdAsync(int id);
    Task<Applicant?> GetApplicantByEmailAsync(string email);
    Task<bool> CreateApplicantAsync(Applicant applicant);
    Task UpdateApplicantAsync(Applicant applicant);
    Task DeleteApplicantAsync(int id);
}