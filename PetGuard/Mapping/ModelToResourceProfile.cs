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
            CreateMap<Client, ClientResource>();
            CreateMap<PetKeeper, PetKeeperResource>();
            CreateMap<Service, ServiceResource>();
            CreateMap<User, UserResource>();
            CreateMap<Card, CardResource>();
            CreateMap<Chat, ChatResource>();
            CreateMap<Message, MessageResource>();
            CreateMap<Payment, PaymentResource>();
            CreateMap<Pet, PetResource>();
        }
    }
}
