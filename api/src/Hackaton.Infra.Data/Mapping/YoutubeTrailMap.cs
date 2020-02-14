using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class YoutubeTrailMap : IEntityTypeConfiguration<YoutubeTrailEntity>
    {
        public void Configure(EntityTypeBuilder<YoutubeTrailEntity> builder)
        {
            builder.ToTable("YoutubeTrail");
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Url).IsRequired();
            builder.HasOne(e => e.Trail).WithOne();
        }
    }
}