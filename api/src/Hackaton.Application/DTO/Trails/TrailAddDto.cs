using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Application.DTO
{
    public class TrailAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Reward { get; set; }
    }
}