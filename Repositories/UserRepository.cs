﻿using JobSeekerAPI.Data;
using JobSeekerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerAPI.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ManagementSystemContext _context;
        public UserRepository(ManagementSystemContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User?> GetByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }   
}