using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class TrailEntity : BaseEntity
    {
        public string Title { get; set; }
        public int TypeID { get; set; }

        [ForeignKey("TypeID")]
        public TrailTypeEntity Type { get; set; }
        public int Reward { get; set; }

    }
}