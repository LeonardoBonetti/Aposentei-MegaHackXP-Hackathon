using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Interfaces;
using Hackaton.Application.Interfaces.Services;
using Hackaton.Application.Validators;

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

        public async Task<UserLoginResponseDto> Login(UserLoginRequestDto login)
        {

            try
            {

                var validate = new UserLoginValidator().Validate(login);

                if (!validate.IsValid)
                {
                    return new UserLoginResponseDto()
                    {
                        Sucess = false,
                        Message = validate.Errors[0].ErrorMessage
                    };
                }

                var result = _mapper.Map<UserEntityDto>((await _repository.LoginAsync(_mapper.Map<User>(login))));

                if (result != null)
                {
                    return new UserLoginResponseDto()
                    {
                        Sucess = true,
                        Message = "Login realizado com sucesso",
                        User = result
                    };
                }
                else
                {
                    return new UserLoginResponseDto()
                    {
                        Sucess = false,
                        Message = "Usuário ou senha incorreto"
                    };
                }

            }
            catch (Exception e)
            {
                return new UserLoginResponseDto()
                {
                    Sucess = false,
                    Message = "Ocorreu um erro, tente novamente"
                };
            }

        }
        public async Task<UserRegisterResponseDto> Register(UserRegisterRequestDto register)
        {
            try
            {
                var validate = new UserRegisterValidator().Validate(register);

                if (!validate.IsValid)
                {
                    return new UserRegisterResponseDto()
                    {
                        Sucess = false,
                        Message = validate.Errors[0].ErrorMessage
                    };
                }

                var userExists = await _repository.UserExists(register.Email);

                if (userExists)
                {
                    return new UserRegisterResponseDto()
                    {
                        Sucess = false,
                        Message = "Usuário já existe, tente outro email"
                    };
                }
                else
                {
                    var result = _mapper.Map<UserEntityDto>(await _repository.InsertAsync(_mapper.Map<User>(register)));

                    return new UserRegisterResponseDto()
                    {
                        Sucess = true,
                        Message = "Usuário cadastrado com sucesso",
                        User = result
                    };
                }
            }
            catch (Exception e)
            {
                return new UserRegisterResponseDto()
                {
                    Sucess = false,
                    Message = "Ocorreu um erro, tente novamente"
                };
            }
        }

        public async Task<UserResponseDto> UpdateTrailUser(UpdateUserTrailRequestDto trail)
        {
            var user = await _repository.SelectAsync(trail.UserID);
            if (user == null)
                throw new Exception("usuário não encontrado");

            //Validação para verificar se trilha existe
            user.TrailID = trail.TrailID;
            var result = await _repository.UpdateAsync(user);
            return _mapper.Map<UserResponseDto>(result);
        }
    }
}