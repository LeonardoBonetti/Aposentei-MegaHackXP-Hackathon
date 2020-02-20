using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class Trail : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Reward { get; set; }
        public int TypeID { get; set; }
        public TrailType TrailType { get; set; }

        public List<User> Users { get; set; }

    }
}