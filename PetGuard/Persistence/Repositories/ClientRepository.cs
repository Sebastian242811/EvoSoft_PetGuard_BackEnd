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
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task<Client> FindByEmail(string email)
        {
            return await _context.Clients.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Client> FindById(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<IEnumerable<Client>> ListByLastNameAsync(string lastName)
        {
            return await _context.Clients
                .Where(p => p.LastName == lastName)
                .Include(p => p.FirstName)
                .Include(p => p.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Client>> ListByNameAsync(string firstName)
        {
            return await _context.Clients
                .Where(p => p.FirstName == firstName)
                .Include(p => p.FirstName)
                .Include(p => p.LastName)
                .ToListAsync();
        }

        public void Remove(Client client)
        {
            _context.Clients.Remove(client);
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
        }
    }
}
