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
    public class MessageService : IMessageService
    {
        public readonly IMessageRepository _messageRepository;
        public readonly IUnitOfWork _unitOfWork;

        public MessageService(IUnitOfWork unitOfWork, IMessageRepository messageRepository)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
        }

        public async Task<MessageResponse> DeleteAsync(int id)
        {
            var existingMessage = await _messageRepository.FindById(id);


            try
            {
                _messageRepository.Remove(existingMessage);
                await _unitOfWork.CompleteAsync();
                return new MessageResponse(existingMessage);
            }
            catch (Exception e)
            {
                return new MessageResponse($"An error ocurred while deleting the Message: {e.Message}");
            }
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _messageRepository.ListAsync();
        }

        public async Task<IEnumerable<Message>> ListMessagesbyChatIdAsync(int id)
        {
            return await _messageRepository.ListMessageByChatId(id); 
        }

        public async Task<MessageResponse> SaveAsync(Message message)
        {
            try
            {
                await _messageRepository.AddAsync(message);
                await _unitOfWork.CompleteAsync();
                return new MessageResponse(message);
            }
            catch (Exception e)
            {
                return new MessageResponse($"An error ocurred while saving the Message: {e.Message}");
            }
        }
    }
}
