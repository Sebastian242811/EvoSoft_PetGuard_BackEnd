using Microsoft.EntityFrameworkCore;
using PetGuard.Domain.Models;
using PetGuard.Domain.Persistence.Contexts;
using PetGuard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Message Message)
        {
            await _context.Messages.AddAsync(Message);
        }

        public async Task<Message> FindById(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return  await _context.Messages.ToListAsync();
        }

        public async Task<IEnumerable<Message>> ListMessageByChatId(int id)
        {
            return await _context.Messages.Where(p => p.ChatId == id).ToListAsync();
        }

        public void Remove(Message Message)
        {
            _context.Messages.Remove(Message);
        }
    }
}
