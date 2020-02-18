using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class YoutubeTrailEntity : BaseEntity
    {
        public string Url { get; set; }
        public int TrailID { get; set; }

        //[ForeignKey("TrailID")]
        public TrailEntity Trail { get; set; }
        public string Paragraphs { get; set; }
    }
}