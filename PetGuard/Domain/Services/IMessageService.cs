using PetGuard.Domain.Models;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> ListAsync();
        Task<IEnumerable<Message>> ListMessagesbyChatIdAsync(int id);
        Task<MessageResponse> SaveAsync(Message message);
        Task<MessageResponse> DeleteAsync(int id);
    }
}
