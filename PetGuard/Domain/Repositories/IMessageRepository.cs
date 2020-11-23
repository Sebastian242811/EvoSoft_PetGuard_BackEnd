using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> FindById(int id);
        Task<IEnumerable<Message>> ListAsync();
        Task<IEnumerable<Message>> ListMessageByChatId(int id);
        Task AddAsync(Message message);
        void Remove(Message message);
    }
}
