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
    public class PetKeeperService : IPetKeeperService
    {
        private readonly IPetKeeperRepository _petKeeperRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PetKeeperService(IPetKeeperRepository petKeeperRepository, IUnitOfWork unitOfWork)
        {
            _petKeeperRepository = petKeeperRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<PetKeeperResponse> DeleteAsync(int id)
        {
            var existingPetKeeper = await _petKeeperRepository.FindById(id);
            if (existingPetKeeper == null)
                return new PetKeeperResponse("PetKeeper not found");
            try
            {
                _petKeeperRepository.Remove(existingPetKeeper);
                await _unitOfWork.CompleteAsync();
                return new PetKeeperResponse(existingPetKeeper);
            }
            catch (Exception ex)
            {
                return new PetKeeperResponse($"An error ocurred while deleting PetKeeper: {ex.Message}");
            }
        }

        public async Task<PetKeeperResponse> GetByIdAsync(int id)
        {
            var existingPetKeeper = await _petKeeperRepository.FindById(id);
            if (existingPetKeeper == null)
                return new PetKeeperResponse("PetKeeper not found");
            return new PetKeeperResponse(existingPetKeeper);
        }

        public async Task<PetKeeperResponse> GetByEmailAsync(string email)
        {
            var existingPetKeeper = await _petKeeperRepository.FindByEmail(email);
            if (existingPetKeeper == null)
                return new PetKeeperResponse("PetKeeper not found");
            return new PetKeeperResponse(existingPetKeeper);
        }

        public async Task<IEnumerable<PetKeeper>> GetByLastnameAsync(string lastName)
        {
            return await _petKeeperRepository.ListByLastName(lastName);
        }

        public async Task<IEnumerable<PetKeeper>> GetByFirstNameAsync(string firstName)
        {
            return await _petKeeperRepository.ListByFirstName(firstName);
        }

        public async Task<IEnumerable<PetKeeper>> ListAsync()
        {
            return await _petKeeperRepository.ListAsync();
        }

        public async Task<PetKeeperResponse> SaveAsync(PetKeeper petKeeper)
        {
            try
            {
                await _petKeeperRepository.AddAsync(petKeeper);
                await _unitOfWork.CompleteAsync();
                return new PetKeeperResponse(petKeeper);
            }
            catch (Exception ex)
            {
                return new PetKeeperResponse($"An error ocurred while saving the PetKeeper: {ex.Message}");
            }
        }

        public async Task<PetKeeperResponse> UpdateAsync(int id, PetKeeper petKeeper)
        {
            var existingPetKeeper = await _petKeeperRepository.FindById(id);
            if (existingPetKeeper == null)
                return new PetKeeperResponse("PetKeeper not found");
            existingPetKeeper.FirstName = petKeeper.FirstName;
            existingPetKeeper.LastName = petKeeper.LastName;
            existingPetKeeper.Email = petKeeper.Email;
            existingPetKeeper.Password = petKeeper.Password;
            existingPetKeeper.Picture = petKeeper.Picture;
            existingPetKeeper.Birthday = petKeeper.Birthday;
            try
            {
                _petKeeperRepository.Update(existingPetKeeper);
                await _unitOfWork.CompleteAsync();
                return new PetKeeperResponse(existingPetKeeper);
            }
            catch (Exception ex)
            {
                return new PetKeeperResponse($"An error ocurred while updating the PetKeeper: {ex.Message}");
            }
        }
    }
}
