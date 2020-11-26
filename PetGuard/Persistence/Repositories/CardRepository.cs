using PetGuard.Domain.Models;
using PetGuard.Domain.Persistence.Contexts;
using PetGuard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Persistence.Repositories
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public CardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
        }

        public async Task<Card> FindById(int id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public void Remove(Card card)
        {
             _context.Cards.Remove(card);
        }

        public void Update(Card card)
        {
            _context.Cards.Update(card);
        }
    }
}
