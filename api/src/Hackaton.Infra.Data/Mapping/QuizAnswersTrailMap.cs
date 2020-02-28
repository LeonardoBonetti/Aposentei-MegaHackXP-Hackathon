using System;
using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class QuizAnswersTrailMap : IEntityTypeConfiguration<QuizAnswersTrail>
    {
        public void Configure(EntityTypeBuilder<QuizAnswersTrail> builder)
        {
            builder.ToTable("QuizAnswersTrails");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Quiz).WithMany(d => d.Answers).HasForeignKey(p => p.QuizID);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Correctly).IsRequired();

        }
    }
}
