using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task AddAsync(Payment payment);
        Task<Payment> FindById(int id);
        void Update(Payment payment);
        void Remove(Payment payment);
    }
}
