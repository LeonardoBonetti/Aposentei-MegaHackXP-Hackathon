using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class QuizAnswersMap : IEntityTypeConfiguration<QuizAnswersEntity>
    {
        public void Configure(EntityTypeBuilder<QuizAnswersEntity> builder)
        {
            builder.ToTable("QuizAnswers");
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Description).IsRequired();
            //HasOneWithMany
            builder.HasOne(e => e.Quiz).WithOne();
        }
    }
}
