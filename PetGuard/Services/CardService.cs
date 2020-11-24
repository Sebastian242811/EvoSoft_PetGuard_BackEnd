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
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CardService(IUnitOfWork unitOfWork, ICardRepository cardRepository)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
        }

        public async Task<CardResponse> DeleteAsync(int id)
        {
            var existingCard = await _cardRepository.FindById(id);
            if (existingCard == null)
                return new CardResponse("Card not found");

            try
            {
                _cardRepository.Remove(existingCard);
                await _unitOfWork.CompleteAsync();
                return new CardResponse(existingCard);
            }
            catch (Exception e)
            {
                return new CardResponse($"An error ocurred while deleting the Card: {e.Message}");
            }
        }

        public async Task<CardResponse> FindCardById(int id)
        {
            var existingCard = await _cardRepository.FindById(id);
            if (existingCard == null)
                return new CardResponse("Card not found");
            return new CardResponse(existingCard);
        }

        public async Task<CardResponse> UpdateAsync(int id, Card card)
        {
            var existingCard = await _cardRepository.FindById(id);
            if (existingCard == null)
                return new CardResponse("Card not found");

            existingCard.CardName = card.CardName;
            existingCard.CardNumber = card.CardNumber;
            existingCard.ExpDate = card.ExpDate;
            try
            {
                _cardRepository.Update(existingCard);
                await _unitOfWork.CompleteAsync();
                return new CardResponse(existingCard);
            }
            catch (Exception e)
            {
                return new CardResponse($"An error ocurred while updating the Card: {e.Message}");
            }
        }
    }
}
