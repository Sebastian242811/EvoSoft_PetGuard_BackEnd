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
    public class PetRepository : BaseRepository, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Pet Pet)
        {
            await _context.Pets.AddAsync(Pet);
        }

        public async Task<Pet> FindById(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<IEnumerable<Pet>> ListAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public void Remove(Pet Pet)
        {
            _context.Pets.Remove(Pet);
        }

        public void Update(Pet Pet)
        {
            _context.Pets.Update(Pet);
        }
    }
}
