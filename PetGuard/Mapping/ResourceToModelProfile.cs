﻿using AutoMapper;
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
            CreateMap<SaveClientResource, Client>();
            CreateMap<SavePetKeeperResource, PetKeeper>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveCardResource, Card>();
            CreateMap<SaveChatResource, Chat>();
            CreateMap<SaveMessageResource, Message>();
            CreateMap<SavePaymentResource, Payment>();
            CreateMap<SavePetResource, Pet>();
        }
    }
}
