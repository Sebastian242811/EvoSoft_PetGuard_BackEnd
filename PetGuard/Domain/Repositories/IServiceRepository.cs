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
        Task AddAsync(Service service);
        Task<Service> FindById(int id);
        Task<Service> FindByClientIdAndPetKeeperId(int clientId, int petKeeperId);
        Task<IEnumerable<Service>> ListByClientIdAsync(int clientId);
        Task<IEnumerable<Service>> ListByPetKeeperIdAsync(int petKeeperId);
        void Update(Service service);
        void Remove(Service service);

    }
}
