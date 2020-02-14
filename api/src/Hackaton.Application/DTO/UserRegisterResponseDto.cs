using System;

namespace Hackaton.Application.DTO
{
    public class UserRegisterResponseDto
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public UserEntityDto User { get; set; }

    }
}