using PetGuard.Domain.Models;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface IChatService
    {
        Task<IEnumerable<Chat>> ListAsync();
        Task<ChatResponse> FindChatById(int id);
        Task<ChatResponse> SaveAsync(Chat chat);
        Task<ChatResponse> DeleteAsync(int id);
    }
}
