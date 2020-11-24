using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services.Communications
{
    public class CardResponse : BaseResponse<Card>
    {
        public CardResponse(Card resource) : base(resource)
        {
        }

        public CardResponse(string message) : base(message)
        {
        }
    }
}
