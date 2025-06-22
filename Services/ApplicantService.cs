using JobSeekerAPI.Models;
using JobSeekerAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JobSeekerAPI.Services;

public class ApplicantService : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantService(IApplicantRepository applicantRepo)
    {
        _applicantRepository = applicantRepo;
    }

    public async Task<IEnumerable<Applicant>> GetAllApplicantAsync()
        => await _applicantRepository.GetAllAsync();

    public async Task<bool> CreateApplicantAsync(Applicant applicant)
    {
        await _applicantRepository.AddAsync(applicant);
        return await _applicantRepository.SaveChangesAsync();
    }

    public async Task UpdateApplicantAsync(Applicant applicant)
    {
        _applicantRepository.Update(applicant);
        await _applicantRepository.SaveChangesAsync();
    }

    public async Task<Applicant?> GetApplicantByIdAsync(int id)
    {
        return await _applicantRepository.GetByIdAsync(id);
    }

    public async Task<Applicant?> GetApplicantByEmailAsync(string email)
    {
        return await _applicantRepository.GetByEmailAsync(email);
    }

    public async Task DeleteApplicantAsync(int id)
    {
        var applicant = await _applicantRepository.GetByIdAsync(id);
        if (applicant != null)
        {
            _applicantRepository.Delete(applicant);
            await _applicantRepository.SaveChangesAsync();
        }
    }
}