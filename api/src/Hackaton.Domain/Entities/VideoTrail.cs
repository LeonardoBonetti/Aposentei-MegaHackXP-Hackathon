using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton.Domain.Entities
{
    public class VideoTrail : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Paragraphs { get; set; }
        public string Url { get; set; }
        public int TrailID { get; set; }
        public Trail Trail { get; set; }

    }
}