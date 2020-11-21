using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> ListAsync();
        Task AddAsync(Pet pet);
        Task<Pet> FindById(int id);
        void Update(Pet pet);
        void Remove(Pet pet);
    }
}
