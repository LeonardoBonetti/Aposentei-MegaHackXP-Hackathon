using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class TrailMap : IEntityTypeConfiguration<TrailEntity>
    {
        public void Configure(EntityTypeBuilder<TrailEntity> builder)
        {
            builder.ToTable("Trails");
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Reward).IsRequired();
            builder.HasOne(x => x.TrailTypeEntity)
                    .WithMany(g => g.TrailEntity)
                    .HasForeignKey(s => s.TypeID);
        }
    }
}
