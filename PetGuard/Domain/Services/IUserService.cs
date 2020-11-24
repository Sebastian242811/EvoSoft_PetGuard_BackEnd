using PetGuard.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetByEmailAsync(string email);
    }
}
