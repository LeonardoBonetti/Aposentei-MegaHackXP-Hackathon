using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Application.DTO
{
    public class TrailResponseDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TypeID { get; set; }
        public string Reward { get; set; }
        public TrailTypeDto TrailTypeDto { get; set; }

    }
}