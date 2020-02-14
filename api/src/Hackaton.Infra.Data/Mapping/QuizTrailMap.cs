using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class QuizTrailMap : IEntityTypeConfiguration<QuizTrailEntity>
    {
        public void Configure(EntityTypeBuilder<QuizTrailEntity> builder)
        {
            builder.ToTable("QuizTrail");
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Description).IsRequired();
            builder.HasOne(e => e.Trail).WithOne();
            builder.HasMany(e => e.Answers).WithOne(x => x.Quiz).HasForeignKey(f => f.QuizID);
        }
    }
}