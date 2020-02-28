using System;

namespace Hackaton.Application.DTO
{
    public class TextTrailAddRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Paragraphs { get; set; }
        public TrailAddDto Trail { get; set; }
    }
}