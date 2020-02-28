using System;

namespace Hackaton.Application.DTO
{
    public class VideoTrailAddRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Paragraphs { get; set; }
        public string Url { get; set; }
        public TrailAddDto Trail { get; set; }
    }
}