using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        public int TrailID { get; set; }
        public Trail Trail { get; set; }
    }
}