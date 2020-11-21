using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> ListAsync();
        Task AddAsync(Chat chat);
        Task<Chat> FindById(int id);
        void Remove(Chat chat);
    }
}
