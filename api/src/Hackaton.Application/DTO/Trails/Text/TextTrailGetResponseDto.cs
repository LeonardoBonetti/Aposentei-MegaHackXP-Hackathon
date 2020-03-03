using System;

namespace Hackaton.Application.DTO
{
    public class TextTrailGetResponseDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Paragraphs { get; set; }
        public TrailResponseDto Trail { get; set; }
    }
}