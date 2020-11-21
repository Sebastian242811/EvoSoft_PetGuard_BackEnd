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
    public class PetKeeperRepository : BaseRepository, IPetKeeperRepository
    {
        public PetKeeperRepository(AppDbContext context) : base(context)
        { }
        public async Task AddAsync(PetKeeper petKeeper)
        {
            await _context.PetKeepers.AddAsync(petKeeper);
        }

        public async Task<PetKeeper> FindById(int id)
        {
            return await _context.PetKeepers.FindAsync(id);
        }

        public async Task<PetKeeper> FindByEmail(string email)
        {
            return await _context.PetKeepers.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<IEnumerable<PetKeeper>> ListByFirstName(string firstName)
        {
            return await _context.PetKeepers.Where(b => b.FirstName == firstName)
                .Include(p => p.FirstName)
                .Include(p => p.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<PetKeeper>> ListByLastName(string lastName)
        {
            return await _context.PetKeepers.Where(b => b.LastName == lastName)
                .Include(p => p.FirstName)
                .Include(p => p.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<PetKeeper>> ListAsync()
        {
            return await _context.PetKeepers.ToListAsync();
        }

        public void Remove(PetKeeper petKeeper)
        {
            _context.PetKeepers.Remove(petKeeper);
        }

        public void Update(PetKeeper petKeeper)
        {
            _context.PetKeepers.Update(petKeeper);
        }
    }
}
