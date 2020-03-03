using System;
using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class VideoTrailMap : IEntityTypeConfiguration<VideoTrail>
    {
        public void Configure(EntityTypeBuilder<VideoTrail> builder)
        {
            builder.ToTable("VideoTrails");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Trail).WithMany(x => x.VideoTrails).HasForeignKey(p => p.TrailID);

            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Paragraphs).IsRequired();
            builder.Property(p => p.Url).IsRequired();

        }
    }
}
