using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services.Communications
{
    public class ClientResponse : BaseResponse<Client>
    {
        public ClientResponse(Client resource) : base(resource)
        {
        }

        public ClientResponse(string message) : base(message)
        {
        }
    }
}
