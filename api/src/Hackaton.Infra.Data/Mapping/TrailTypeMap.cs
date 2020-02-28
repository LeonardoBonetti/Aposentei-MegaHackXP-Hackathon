using System;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Enums;
using Hackaton.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class TrailTypeMap : IEntityTypeConfiguration<TrailType>
    {
        public void Configure(EntityTypeBuilder<TrailType> builder)
        {
            builder.ToTable("TrailType");
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Description).IsRequired();
            builder.HasData(
                new TrailType() { Id = (int)TrailTypeEnum.Text, Description = TrailTypeEnum.Text.GetDisplayAttributeFrom(typeof(TrailTypeEnum)), CreateAt = DateTime.Now },
                new TrailType() { Id = (int)TrailTypeEnum.Video, Description = TrailTypeEnum.Video.GetDisplayAttributeFrom(typeof(TrailTypeEnum)), CreateAt = DateTime.Now },
                new TrailType() { Id = (int)TrailTypeEnum.Quiz, Description = TrailTypeEnum.Quiz.GetDisplayAttributeFrom(typeof(TrailTypeEnum)), CreateAt = DateTime.Now }
            );
        }
    }
}