using JobSeekerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSeekerAPI.Repositories;

public interface IApplicantRepository : IRepository<Applicant>
{
    Task<Applicant?> GetByEmailAsync(string email);
}