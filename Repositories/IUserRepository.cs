using JobSeekerAPI.Models;

namespace JobSeekerAPI.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}