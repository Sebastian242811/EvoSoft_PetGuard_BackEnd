using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
        Task AddAsync(Client client);
        Task<Client> FindById(int id);
        Task<Client> FindByEmail(string email);
        Task<IEnumerable<Client>> ListByNameAsync(string firstName);
        Task<IEnumerable<Client>> ListByLastNameAsync(string lastName);
        void Update(Client client);
        void Remove(Client client);
    }
}
