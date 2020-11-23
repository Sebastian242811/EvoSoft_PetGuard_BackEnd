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
    public class ChatService : IChatService
    {
        public readonly IChatRepository _chatRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ChatService(IUnitOfWork unitOfWork, IChatRepository chatRepository)
        {
            _unitOfWork = unitOfWork;
            _chatRepository = chatRepository;
        }

        public async Task<ChatResponse> DeleteAsync(int id)
        {
            var existingChat = await _chatRepository.FindById(id);
            if (existingChat == null)
                return new ChatResponse("Chat not found");

            try
            {
                _chatRepository.Remove(existingChat);
                await _unitOfWork.CompleteAsync();
                return new ChatResponse(existingChat);
            }
            catch (Exception e)
            {
                return new ChatResponse($"An error ocurred while deleting the Chat: {e.Message}");
            }
        }

        public async Task<ChatResponse> FindChatById(int id)
        {
            var existingChat = await _chatRepository.FindById(id);
            if (existingChat == null)
                return new ChatResponse("Chat not found");
            return new ChatResponse(existingChat);
        }

        public async Task<IEnumerable<Chat>> ListAsync()
        {
            return await _chatRepository.ListAsync();
        }

        public async Task<ChatResponse> SaveAsync(Chat chat)
        {
            try
            {
                await _chatRepository.AddAsync(chat);
                await _unitOfWork.CompleteAsync();
                return new ChatResponse(chat);
            }
            catch (Exception e)
            {
                return new ChatResponse($"An error ocurred while saving the Chat: {e.Message}");
            }
        }

    }
}
