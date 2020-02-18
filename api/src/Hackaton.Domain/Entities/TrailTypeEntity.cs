using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackaton.Domain.Entities
{
    public class TrailTypeEntity : BaseEntity
    {
        public string Description { get; set; }
    }
}