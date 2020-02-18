using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class TextTrailMap : IEntityTypeConfiguration<TextTrailEntity>
    {
        public void Configure(EntityTypeBuilder<TextTrailEntity> builder)
        {
            builder.ToTable("TextTrail");
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Paragraphs).IsRequired();
            builder.HasOne(x => x.Trail)
                    .WithMany(g => g.TextTrailEntity)
                    .HasForeignKey(s => s.TrailID);
        }
    }
}