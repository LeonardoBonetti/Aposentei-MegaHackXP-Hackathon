using System;
using System.ComponentModel.DataAnnotations;

namespace Hackaton.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        public int TrailID { get; set; }
    }
}