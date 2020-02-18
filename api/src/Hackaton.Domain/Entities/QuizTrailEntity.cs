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

        [ForeignKey("TrailID")]
        public List<TrailEntity> Trail { get; set; }
        public List<QuizAnswersEntity> Answers { get; set; }

    }
}