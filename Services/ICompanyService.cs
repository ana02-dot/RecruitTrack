using JobSeekerAPI.Models;

namespace JobSeekerAPI.Services
{
    public interface ICompanyService
    {
        Task<bool> CreateCompanyAsync(Company company);
        Task<IEnumerable<Company>> GetAllCompanyAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
        Task<Company?> GetCompanyByNameAsync(string name);
    }
}
