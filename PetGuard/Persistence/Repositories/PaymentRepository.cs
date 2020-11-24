using Microsoft.EntityFrameworkCore;
using PetGuard.Domain.Models;
using PetGuard.Domain.Persistence.Contexts;
using PetGuard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task<Payment> FindById(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public void Remove(Payment Payment)
        {
            _context.Payments.Remove(Payment);
        }

        public void Update(Payment Payment)
        {
            _context.Payments.Update(Payment);
        }
    }
}
