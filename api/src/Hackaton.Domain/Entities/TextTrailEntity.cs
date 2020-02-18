using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class TextTrailEntity : BaseEntity
    {
        public string Paragraphs { get; set; }
        public int TrailID { get; set; }

        //[ForeignKey("TrailID")]
        public TrailEntity Trail { get; set; }

    }
}