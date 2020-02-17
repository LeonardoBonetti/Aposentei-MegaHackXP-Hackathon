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
            //Tirar de todas(exeto as que tem lista(resposta))
            builder.HasOne(e => e.Type).WithOne();
        }
    }
}
