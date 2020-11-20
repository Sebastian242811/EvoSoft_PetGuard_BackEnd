using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services.Communications
{
    public class PetResponse : BaseResponse<Pet>
    {
        public PetResponse(Pet resource) : base(resource)
        {
        }

        public PetResponse(string message) : base(message)
        {
        }
    }
}
