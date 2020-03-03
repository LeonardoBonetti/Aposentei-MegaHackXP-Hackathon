using System;

namespace Hackaton.Application.DTO
{
    public class VideoTrailGetResponseDto
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Paragraphs { get; set; }
        public string Url { get; set; }
        public TrailResponseDto Trail { get; set; }
    }
}