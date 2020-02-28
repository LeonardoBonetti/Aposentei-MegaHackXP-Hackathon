using System;
using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class QuizTrailMap : IEntityTypeConfiguration<QuizTrail>
    {
        public void Configure(EntityTypeBuilder<QuizTrail> builder)
        {
            builder.ToTable("QuizTrails");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Trail).WithMany().HasForeignKey(p => p.TrailID);
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
