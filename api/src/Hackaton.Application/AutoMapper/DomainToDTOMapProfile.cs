using AutoMapper;
using Hackaton.Application.DTO;
using Hackaton.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackaton.Application.AutoMapper
{
    public class DomainToDTOMapProfile : Profile
    {
        public DomainToDTOMapProfile()
        {
            CreateMap<User, UserEntityDto>();
            CreateMap<Trail, TrailResponseDto>();
            CreateMap<TrailType, TrailTypeDto>();
            CreateMap<User, UserResponseDto>();
        }
    }
}