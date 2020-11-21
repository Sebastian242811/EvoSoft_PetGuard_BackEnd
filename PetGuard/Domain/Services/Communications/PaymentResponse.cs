using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services.Communications
{
    public class PaymentResponse : BaseResponse<Payment>
    {
        public PaymentResponse(Payment resource) : base(resource)
        {
        }

        public PaymentResponse(string message) : base(message)
        {
        }
    }
}
