using PetGuard.Domain.Models;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> ListAsync();
        Task<ServiceResponse> GetByIdAsync(int id);
        Task<ServiceResponse> GetByClientIdAndPetKeeperId(int clientId, int petKeeperId);
        Task<IEnumerable<Service>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<Service>> GetByPetKeeperAsync(int petKeeperId);
        Task<ServiceResponse> SaveAsync(Service service);
        Task<ServiceResponse> UpdateAsync(int id, Service service);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
