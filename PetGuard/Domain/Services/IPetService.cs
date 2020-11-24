using PetGuard.Domain.Models;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> ListAsync();
        Task<PetResponse> FindPetById(int id);
        Task<PetResponse> SaveAsync(Pet pet);
        Task<PetResponse> UpdateAsync(int id, Pet pet);
        Task<PetResponse> DeleteAsync(int id);
    }
}
