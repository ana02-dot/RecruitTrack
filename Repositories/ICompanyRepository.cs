using JobSeekerAPI.Models;

namespace JobSeekerAPI.Repositories
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<Company?> GetCompanyByNameAsync(string name);
    }
}