using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Domain.Entities;

namespace Hackaton.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntityDto> Get(int id);
        Task<IEnumerable<UserEntityDto>> GetAll();
        Task<UserEntityDto> Register(UserEntityDto user);
        Task<UserEntityLoginDto> Login(UserEntityDto user);
    }
}