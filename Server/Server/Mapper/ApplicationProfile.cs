using AutoMapper;
using Domain;
using Server.Models.Auth;
using Server.Models.PetPassport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<LoginModel, User>()
                .ReverseMap();
            CreateMap<RegisterModel, User>()
                .ReverseMap();
            CreateMap<CreatePetPassportModel, PetPassport>()
                .ReverseMap();
            CreateMap<UpdateIdealBloodTestModel, BloodTest>()
                .ReverseMap();
        }
    }

}
