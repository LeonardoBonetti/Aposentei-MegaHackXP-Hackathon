using System;
using System.Collections.Generic;

namespace Hackaton.Application.DTO
{
    public class QuizTrailGetResponseDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public ICollection<QuizAnswersTrailAddRequestDto> Answers { get; set; }
        public TrailResponseDto Trail { get; set; }
    }
}