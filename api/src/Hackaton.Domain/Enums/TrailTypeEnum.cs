using System;
using System.ComponentModel.DataAnnotations;

namespace Hackaton.Domain.Enums
{
    public enum TrailTypeEnum
    {
        [Display(Name = "Texto", ResourceType = typeof(TrailTypeEnum))]
        Text = 1,
        [Display(Name = "Video", ResourceType = typeof(TrailTypeEnum))]
        Video = 2,
        [Display(Name = "Quiz", ResourceType = typeof(TrailTypeEnum))]
        Quiz = 3
    }
}