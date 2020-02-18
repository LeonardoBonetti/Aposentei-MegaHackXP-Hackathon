using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class QuizAnswersEntity : BaseEntity
    {
        public string Description { get; set; }
        public Boolean Correclty { get; set; }
        public int QuizID { get; set; }

        //[ForeignKey("QuizID")]
        public QuizTrailEntity Quiz { get; set; }

    }
}