using Microsoft.EntityFrameworkCore;
using PetGuard.Domain.Models;
using PetGuard.Domain.Persistence.Contexts;
using PetGuard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> FindByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
        }
    }
}
