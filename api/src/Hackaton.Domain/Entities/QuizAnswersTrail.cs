using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class QuizAnswersTrail : BaseEntity
    {
        public string Description { get; set; }
        public Boolean Correctly { get; set; }
        public int QuizID { get; set; }
        public QuizTrail Quiz { get; set; }

    }
}