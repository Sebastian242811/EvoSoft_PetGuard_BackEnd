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

        public async Task AssignService(int clientId, int petKeeperId)
        {
            Service service = await _context.Services.FindAsync(clientId, petKeeperId);
            if (service != null)
                await AddAsync(service);
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
                .Include(p => p.ClientId)
                .Include(P => P.PetKeeperId)
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

        public async void UnassignService(int clientId, int petKeeperId)
        {
            Service service = await _context.Services.FindAsync(clientId, petKeeperId);
            if (service != null)
                Remove(service);
        }
    }
}
