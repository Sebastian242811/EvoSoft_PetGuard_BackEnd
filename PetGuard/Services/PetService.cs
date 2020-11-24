using PetGuard.Domain.Models;
using PetGuard.Domain.Repositories;
using PetGuard.Domain.Services;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PetService(IUnitOfWork unitOfWork, IPetRepository petRepository)
        {
            _unitOfWork = unitOfWork;
            _petRepository = petRepository;
        }

        public async Task<PetResponse> DeleteAsync(int id)
        {
            var existingPet = await _petRepository.FindById(id);
            if (existingPet == null)
                return new PetResponse("Pet not found");

            try
            {
                _petRepository.Remove(existingPet);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(existingPet);
            }
            catch (Exception e)
            {
                return new PetResponse($"An error ocurred while deleting the Pet: {e.Message}");
            }
        }

        public async Task<PetResponse> FindPetById(int id)
        {
            var existingPet = await _petRepository.FindById(id);
            if (existingPet == null)
                return new PetResponse("Pet not found");
            return new PetResponse(existingPet);
        }

        public async Task<IEnumerable<Pet>> ListAsync()
        {
            return await _petRepository.ListAsync();
        }

        public async Task<PetResponse> SaveAsync(Pet pet)
        {
            try
            {
                await _petRepository.AddAsync(pet);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(pet);
            }
            catch (Exception e)
            {
                return new PetResponse($"An error ocurred while saving the Pet: {e.Message}");
            }
        }

        public async Task<PetResponse> UpdateAsync(int id, Pet pet)
        {
            var existingPet = await _petRepository.FindById(id);
            if (existingPet == null)
                return new PetResponse("Pet not found");

            existingPet.ClientId = pet.ClientId;
            existingPet.Name = pet.Name;
            existingPet.Breed = pet.Breed;
            try
            {
                _petRepository.Update(existingPet);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(existingPet);
            }
            catch (Exception e)
            {
                return new PetResponse($"An error ocurred while updating the Pet: {e.Message}");
            }
        }
    }
}
