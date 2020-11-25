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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRepository _serviceRepository;

        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork, IServiceRepository serviceRepository)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
        }

        public async Task<ClientResponse> DeleteAsync(int id)
        {
            var existingClient = await _clientRepository.FindById(id);
            if (existingClient == null)
                return new ClientResponse("Client not found");
            try
            {
                _clientRepository.Remove(existingClient);
                await _unitOfWork.CompleteAsync();
                return new ClientResponse(existingClient);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"An error ocurred while deleting Client: {ex.Message}");
            }
        }

        public async Task<ClientResponse> GetByEmailAsync(string email)
        {
            var existingClient = await _clientRepository.FindByEmail(email);
            if (existingClient == null)
                return new ClientResponse("Client not found");
            return new ClientResponse(existingClient);
        }

        public async Task<ClientResponse> GetByIdAsync(int id)
        {
            var existingClient = await _clientRepository.FindById(id);
            if (existingClient == null)
                return new ClientResponse("Client not found");
            return new ClientResponse(existingClient);
        }

        public async Task<IEnumerable<Client>> GetByLastNameAsync(string lastName)
        {
            return await _clientRepository.ListByLastNameAsync(lastName);
        }

        public async Task<IEnumerable<Client>> GetByNameAsync(string name)
        {
            return await _clientRepository.ListByNameAsync(name);
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _clientRepository.ListAsync();
        }

        public async Task<ClientResponse> SaveAsync(Client client)
        {
            try
            {
                await _clientRepository.AddAsync(client);
                await _unitOfWork.CompleteAsync();
                return new ClientResponse(client);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"An error ocurred while saving the Client: {ex.Message}");
            }
        }

        public async Task<ClientResponse> UpdateAsync(int id, Client client)
        {
            var existingClient = await _clientRepository.FindById(id);
            if (existingClient == null)
                return new ClientResponse("UserChef not found");
            existingClient.FirstName = client.FirstName;
            existingClient.LastName = client.LastName;
            existingClient.Email = client.Email;
            existingClient.Password = client.Password;
            existingClient.Birthday = client.Birthday;
            try
            {
                _clientRepository.Update(existingClient);
                await _unitOfWork.CompleteAsync();
                return new ClientResponse(existingClient);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"An error ocurred while updating the Client: {ex.Message}");
            }
        }
    }
}
