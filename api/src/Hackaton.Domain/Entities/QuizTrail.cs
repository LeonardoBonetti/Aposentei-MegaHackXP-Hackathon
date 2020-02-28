using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackaton.Domain.Entities
{
    public class QuizTrail : BaseEntity
    {
        public string Description { get; set; }
        public ICollection<QuizAnswersTrail> Answers { get; set; }
        public int TrailID { get; set; }
        public Trail Trail { get; set; }

    }
}