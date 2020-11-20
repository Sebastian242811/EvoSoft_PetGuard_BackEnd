using AutoMapper;
using PetGuard.Domain.Models;
using PetGuard.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<PetKeeper, PetKeeperResource>();
            CreateMap<User, UserResource>();
        }
    }
}
