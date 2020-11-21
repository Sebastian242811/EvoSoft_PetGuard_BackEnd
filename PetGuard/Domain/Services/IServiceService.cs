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
        Task<IEnumerable<Service>> ListByClientIdAsync(int clientId);
        Task<IEnumerable<Service>> ListByPetKeeperAsync(int petKeeperId);
        Task<ServiceResponse> AssignServiceAsync(int clientId, int petKeeperId);
        Task<ServiceResponse> UnassignServiceAsync(int clientId, int petKeeperId);
    }
}
