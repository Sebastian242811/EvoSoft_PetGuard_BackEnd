using PetGuard.Domain.Models;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface IPetKeeperService
    {
        Task<IEnumerable<PetKeeper>> ListAsync();
        Task<PetKeeperResponse> GetByIdAsync(int id);
        Task<PetKeeperResponse> GetByEmailAsync(string email);
        Task<IEnumerable<PetKeeper>> GetByFirstNameAsync(string firstName);
        Task<IEnumerable<PetKeeper>> GetByLastnameAsync(string lastName);
        Task<PetKeeperResponse> SaveAsync(PetKeeper petKeeper);
        Task<PetKeeperResponse> UpdateAsync(int id, PetKeeper petKeeper);
        Task<PetKeeperResponse> DeleteAsync(int id);
    }
}
