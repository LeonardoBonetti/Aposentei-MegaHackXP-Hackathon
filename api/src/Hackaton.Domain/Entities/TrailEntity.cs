using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class TrailEntity : BaseEntity
    {
        public string Title { get; set; }
        public int TypeID { get; set; }

        // [ForeignKey("TypeID")]
        public TrailTypeEntity TrailTypeEntity { get; set; }
        public int Reward { get; set; }
        public ICollection<QuizTrailEntity> QuizTrailEntity { get; set; }
        public ICollection<TextTrailEntity> TextTrailEntity { get; set; }
        public ICollection<YoutubeTrailEntity> YoutubeTrailEntity { get; set; }

    }
}