using JobSeekerAPI.Models;
using JobSeekerAPI.Repositories;

namespace JobSeekerAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepo)
        {
            _companyRepository = companyRepo;   
        }

        public async Task<bool> CreateCompanyAsync(Company company)
        {
            await _companyRepository.AddAsync(company);
            return await _companyRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<Company>> GetAllCompanyAsync()
        => await _companyRepository.GetAllAsync();
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }
        public async Task UpdateCompanyAsync(Company company)
        {
            var companyToUpdate = await _companyRepository.GetByIdAsync(company.Id);
            if (companyToUpdate != null)
            {
                companyToUpdate.Name = company.Name;
                companyToUpdate.Description = company.Description;
                companyToUpdate.Industry = company.Industry;
                _companyRepository.Update(companyToUpdate);
                await _companyRepository.SaveChangesAsync();
            }
        }
        public async Task DeleteCompanyAsync(int id)
        {
            var companyToDelete = await _companyRepository.GetByIdAsync(id);
            if (companyToDelete != null)
            {
                _companyRepository.Delete(companyToDelete);
                await _companyRepository.SaveChangesAsync();
            }
        }

        public Task<Company?> GetCompanyByNameAsync(string name)
        => _companyRepository.GetCompanyByNameAsync(name);
    }
}
