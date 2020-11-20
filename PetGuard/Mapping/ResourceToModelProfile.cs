using AutoMapper;
using PetGuard.Domain.Models;
using PetGuard.Resources.Saves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePetKeeperResource, PetKeeper>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
