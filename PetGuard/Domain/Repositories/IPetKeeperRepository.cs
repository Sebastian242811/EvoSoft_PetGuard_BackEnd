using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Repositories
{
    public interface IPetKeeperRepository
    {
        Task<IEnumerable<PetKeeper>> ListAsync();
        Task AddAsync(PetKeeper petKeeper);
        Task<PetKeeper> FindById(int id);
        Task<PetKeeper> FindByEmail(string email);
        Task<IEnumerable<PetKeeper>> ListByFirstName(string firstName);
        Task<IEnumerable<PetKeeper>> ListByLastName(string lastName);
        void Update(PetKeeper petKeeper);
        void Remove(PetKeeper petKeeper);
    }
}
