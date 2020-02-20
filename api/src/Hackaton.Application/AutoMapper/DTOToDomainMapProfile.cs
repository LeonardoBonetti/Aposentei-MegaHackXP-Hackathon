using AutoMapper;
using Hackaton.Application.DTO;
using Hackaton.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackaton.Application.AutoMapper
{
    public class DTOToDomainMapProfile : Profile
    {
        public DTOToDomainMapProfile()
        {
            CreateMap<UserEntityDto, User>();
            CreateMap<UserLoginRequestDto, User>();
            CreateMap<UserRegisterRequestDto, User>();
            CreateMap<UserResponseDto, User>();
        }
    }
}