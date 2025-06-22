using JobSeekerAPI.Data;
using JobSeekerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerAPI.Repositories;

public class ApplicantRepository:Repository<Applicant>, IApplicantRepository
{
    private readonly ManagementSystemContext _context;
    public ApplicantRepository(ManagementSystemContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Applicant?> GetByEmailAsync(string email)
    {
        return await _context.Applicants.FirstOrDefaultAsync(a => a.Email == email);
    }
}