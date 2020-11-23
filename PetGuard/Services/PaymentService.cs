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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository)
        {
            _unitOfWork = unitOfWork;
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentResponse> DeleteAsync(int id)
        {
            var existingPayment = await _paymentRepository.FindById(id);
            if (existingPayment == null)
                return new PaymentResponse("Payment not found");

            try
            {
                _paymentRepository.Remove(existingPayment);
                await _unitOfWork.CompleteAsync();
                return new PaymentResponse(existingPayment);
            }
            catch (Exception e)
            {
                return new PaymentResponse($"An error ocurred while deleting the Payment: {e.Message}");
            }
        }

        public async Task<PaymentResponse> FindPaymentById(int id)
        {
            var existingPayment = await _paymentRepository.FindById(id);
            if (existingPayment == null)
                return new PaymentResponse("Payment not found");
            return new PaymentResponse(existingPayment);
        }

        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _paymentRepository.ListAsync();
        }

        public async Task<PaymentResponse> SaveAsync(Payment payment)
        {
            try
            {
                await _paymentRepository.AddAsync(payment);
                await _unitOfWork.CompleteAsync();
                return new PaymentResponse(payment);
            }
            catch (Exception e)
            {
                return new PaymentResponse($"An error ocurred while saving the Payment: {e.Message}");
            }
        }

        public async Task<PaymentResponse> UpdateAsync(int id, Payment payment)
        {
            var existingPayment = await _paymentRepository.FindById(id);
            if (existingPayment == null)
                return new PaymentResponse("Payment not found");

            existingPayment.CardId = payment.CardId;
            existingPayment.ClientId = payment.ClientId;
            existingPayment.Date = payment.Date;
            try
            {
                _paymentRepository.Update(existingPayment);
                await _unitOfWork.CompleteAsync();
                return new PaymentResponse(existingPayment);
            }
            catch (Exception e)
            {
                return new PaymentResponse($"An error ocurred while updating the Payment: {e.Message}");
            }
        }
    }
}
