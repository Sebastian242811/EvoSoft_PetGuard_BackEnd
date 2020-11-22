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
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        { }
        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
        }

        public async Task<Service> FindById(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<Service> FindByClientIdAndPetKeeperId(int clientId, int petKeeperId)
        {
            return await _context.Services
                .Where(p => p.ClientId == clientId)
                .Where(p => p.PetKeeperId == petKeeperId)
                .Include(p => p.Client)
                .Include(p => p.PetKeeper)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            return await _context.Services
                .Include(p => p.Client)
                .Include(P => P.PetKeeper)
                .ToListAsync();
        }

        public async Task<IEnumerable<Service>> ListByClientIdAsync(int clientId)
        {
            return await _context.Services
                .Where(p => p.ClientId == clientId)
                .Include(p => p.Client)
                .Include(p => p.PetKeeper)
                .ToListAsync();
        }

        public async Task<IEnumerable<Service>> ListByPetKeeperIdAsync(int petKeeperId)
        {
            return await _context.Services
                .Where(p => p.PetKeeperId == petKeeperId)
                .Include(p => p.Client)
                .Include(p => p.PetKeeper)
                .ToListAsync();
        }

        public void Remove(Service service)
        {
            _context.Services.Remove(service);
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
        }
    }
}
