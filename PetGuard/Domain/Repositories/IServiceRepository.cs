using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> ListAsync();
        Task<IEnumerable<Service>> ListByClientIdAsync(int clientId);
        Task<IEnumerable<Service>> ListByPetKeeperIdAsync(int petKeeperId);
        Task<Service> FindByClientIdAndPetKeeperId(int clientId, int petKeeperId);
        Task AddAsync(Service service);
        void Remove(Service service);
        Task AssignService(int clientId, int petKeeperId);
        void UnassignService(int clientId, int petKeeperId);

    }
}
