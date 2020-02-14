using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class TrailTypeMap : IEntityTypeConfiguration<TrailTypeEntity>
    {
        public void Configure(EntityTypeBuilder<TrailTypeEntity> builder)
        {
            builder.ToTable("TrailType");
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Description).IsRequired();
            // builder.HasMany(c => c.Trails).WithOne(e => e.Type);
        }
    }
}