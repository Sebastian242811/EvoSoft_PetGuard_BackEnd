using PetGuard.Domain.Models;
using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task<PaymentResponse> FindPaymentById(int id);
        Task<PaymentResponse> SaveAsync(Payment payment);
        Task<PaymentResponse> UpdateAsync(int id, Payment payment);
        Task<PaymentResponse> DeleteAsync(int id);
    }
}
