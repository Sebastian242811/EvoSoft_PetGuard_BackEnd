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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var existingService = await _serviceRepository.FindById(id);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            try
            {
                _serviceRepository.Remove(existingService);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(existingService);
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred while deleting Service: {ex.Message}");
            }
        }

        public async Task<ServiceResponse> GetByIdAsync(int id)
        {
            var existingService = await _serviceRepository.FindById(id);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            return new ServiceResponse(existingService);
        }

        public async Task<ServiceResponse> GetByClientIdAndPetKeeperId(int clientId, int petKeeperId)
        {
            var existingService = await _serviceRepository.FindByClientIdAndPetKeeperId(clientId, petKeeperId);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            return new ServiceResponse(existingService);
        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            return await _serviceRepository.ListAsync();
        }

        public async Task<IEnumerable<Service>> GetByClientIdAsync(int clientId)
        {
            return await _serviceRepository.ListByClientIdAsync(clientId);
        }

        public async Task<IEnumerable<Service>> GetByPetKeeperAsync(int petKeeperId)
        {
            return await _serviceRepository.ListByPetKeeperIdAsync(petKeeperId);
        }

        public async Task<ServiceResponse> SaveAsync(Service service)
        {
            try
            {
                await _serviceRepository.AddAsync(service);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(service);
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred while saving the Service: {ex.Message}");
            }
        }

        public async Task<ServiceResponse> UpdateAsync(int id, Service service)
        {
            var existingService = await _serviceRepository.FindById(id);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            existingService.Name = service.Name;
            existingService.Description = service.Description;
            existingService.Location = service.Location;
            existingService.StartTime = service.StartTime;
            existingService.Duration = service.Duration;
            existingService.ClientId = service.ClientId;
            existingService.PetKeeperId = service.PetKeeperId;
            try
            {
                _serviceRepository.Update(existingService);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(existingService);
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred while updating the Service: {ex.Message}");
            }
        }
    }
}