using JobSeekerAPI.Data;
using JobSeekerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerAPI.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ManagementSystemContext _context;
        public CompanyRepository(ManagementSystemContext context) : base(context)
        {
           _context = context;
        }

        public async Task<Company?> GetCompanyByNameAsync(string name)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
