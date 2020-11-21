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
        public async Task<ServiceResponse> AssignServiceAsync(int clientId, int petKeeperId)
        {
            try
            {
                await _serviceRepository.AssignService(clientId, petKeeperId);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred while assigning Service: {ex.Message}");
            }
            return new ServiceResponse(await _serviceRepository.FindByClientIdAndPetKeeperId(clientId, petKeeperId));

        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            return await _serviceRepository.ListAsync();
        }

        public async Task<IEnumerable<Service>> ListByClientIdAsync(int clientId)
        {
            return await _serviceRepository.ListByClientIdAsync(clientId);
        }

        public async Task<IEnumerable<Service>> ListByPetKeeperAsync(int petKeeperId)
        {
            return await _serviceRepository.ListByPetKeeperIdAsync(petKeeperId);
        }

        public async Task<ServiceResponse> UnassignServiceAsync(int clientId, int petKeeperId)
        {
            try
            {
                Service service = await _serviceRepository.FindByClientIdAndPetKeeperId(clientId, petKeeperId);
                _serviceRepository.Remove(service);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(service);
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred while unassigning Service: {ex.Message}");
            }
        }
    }
}
