using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Interfaces;
using Hackaton.Application.Interfaces.Services;

namespace Hackaton.Infra.Data.Repository
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserEntityLoginDto> Login(UserEntityDto user)
        {
            var result = await _repository.LoginAsync(_mapper.Map<UserEntity>(user));
            if (result)
            {
                return new UserEntityLoginDto()
                {
                    Sucess = true,
                    Message = "Login realizado com sucesso"
                };
            }
            else
            {
                return new UserEntityLoginDto()
                {
                    Sucess = false,
                    Message = "Usuário ou senha incorreto"
                };
            }
        }
        public async Task<UserEntityDto> Register(UserEntityDto user)
        {
            return _mapper.Map<UserEntityDto>((await _repository.InsertAsync(_mapper.Map<UserEntity>(user))));
        }
        public async Task<UserEntityDto> Get(int id)
        {
            var dbResponse = await _repository.SelectAsync(id);
            return _mapper.Map<UserEntityDto>(dbResponse);
        }
        public async Task<IEnumerable<UserEntityDto>> GetAll()
        {
            var dbResponse = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserEntityDto>>(dbResponse);
        }

    }
}