using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class QuizTrailEntity : BaseEntity
    {
        public string Description { get; set; }
        public int TrailID { get; set; }

        //[ForeignKey("TrailID")]
        public TrailEntity Trail { get; set; }
        public ICollection<QuizAnswersEntity> Answers { get; set; }

    }
}