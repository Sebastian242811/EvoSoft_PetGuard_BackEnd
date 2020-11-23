using PetGuard.Domain.Models;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ListAsync();
        Task<ClientResponse> GetByIdAsync(int id);
        Task<ClientResponse> GetByEmailAsync(string email);
        Task<IEnumerable<Client>> GetByNameAsync(string firstName);
        Task<IEnumerable<Client>> GetByLastNameAsync(string lastName);
        Task<ClientResponse> SaveAsync(Client client);
        Task<ClientResponse> UpdateAsync(int id, Client client);
        Task<ClientResponse> DeleteAsync(int id);
    }
}
