using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services.Communications
{
    public class PetKeeperResponse : BaseResponse<PetKeeper>
    {
        public PetKeeperResponse(string message) : base(message)
        { }
        public PetKeeperResponse(PetKeeper resource) : base(resource)
        { }
    }
}
