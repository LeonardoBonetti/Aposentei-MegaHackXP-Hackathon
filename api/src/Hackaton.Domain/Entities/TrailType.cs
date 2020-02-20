using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackaton.Domain.Entities
{
    public class TrailType : BaseEntity
    {
        public string Description { get; set; }
        public ICollection<Trail> Trails { get; set; }

    }
}