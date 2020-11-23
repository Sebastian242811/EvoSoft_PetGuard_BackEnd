using PetGuard.Domain.Models;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface ICardService
    {
        Task<CardResponse> FindCardById(int id);
        Task<CardResponse> UpdateAsync(int id, Card card);
        Task<CardResponse> DeleteAsync(int id);
    }
}
