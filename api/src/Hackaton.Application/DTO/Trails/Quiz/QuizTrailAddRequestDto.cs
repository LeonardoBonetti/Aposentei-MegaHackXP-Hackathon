using System;
using System.Collections.Generic;

namespace Hackaton.Application.DTO
{
    public class QuizTrailAddRequestDto
    {
        public string Description { get; set; }
        public ICollection<QuizAnswersTrailAddRequestDto> Answers { get; set; }
        public TrailAddDto Trail { get; set; }
    }
}