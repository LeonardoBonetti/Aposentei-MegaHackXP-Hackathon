using System;
using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class TextTrailMap : IEntityTypeConfiguration<TextTrail>
    {
        public void Configure(EntityTypeBuilder<TextTrail> builder)
        {
            builder.ToTable("TextTrails");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Trail).WithMany().HasForeignKey(p => p.TrailID);

            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Paragraphs).IsRequired();

        }
    }
}
