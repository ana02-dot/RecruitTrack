using JobSeekerAPI.Models;
using JobSeekerAPI.Repositories;

namespace JobSeekerAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        => await _userRepository.GetAllAsync();

        public async Task<User?> GetUserByIdAsync(int id)
            => await _userRepository.GetByIdAsync(id);

        public async Task<User?> GetUserByEmailAsync(string email)
            => await _userRepository.GetByEmailAsync(email);

        public async Task<bool> CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                userToUpdate.Role = user.Role;
                _userRepository.Update(userToUpdate);
                await _userRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await _userRepository.GetByIdAsync(id);
            if (userToDelete != null)
            {
                _userRepository.Delete(userToDelete);
                await _userRepository.SaveChangesAsync();
            }
        }
    }
}
