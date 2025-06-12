
using JobSeekerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ManagementSystemContext _context;
        public Repository(ManagementSystemContext context)
        {
            _context = context;
        }

        // Fix for CS1929: Use DbSet<T> from the context and call ToListAsync on it
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity) => await _context.AddAsync(entity);

        public void Update(T entity) => _context.Update(entity);

        public void Delete(T entity) => _context.Remove(entity);

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
