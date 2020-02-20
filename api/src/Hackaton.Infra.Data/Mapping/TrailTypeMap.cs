using System;
using Hackaton.Domain.Entities;
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
                new TrailType() { Id = 1, Description = "Text", CreateAt = DateTime.Now },
                new TrailType() { Id = 2, Description = "Video", CreateAt = DateTime.Now },
                new TrailType() { Id = 3, Description = "Quiz", CreateAt = DateTime.Now }
            );
        }
    }
}