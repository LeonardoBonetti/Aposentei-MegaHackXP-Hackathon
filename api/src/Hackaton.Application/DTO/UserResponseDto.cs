using System;

namespace Hackaton.Application.DTO
{
    public class UserResponseDto
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        public int TrailID { get; set; }
    }
}