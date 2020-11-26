using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Repositories
{
    public interface ICardRepository
    {
        Task AddAsync(Card card);
        Task<Card> FindById(int id);
        void Update(Card card);
        void Remove(Card card);
    }
}
