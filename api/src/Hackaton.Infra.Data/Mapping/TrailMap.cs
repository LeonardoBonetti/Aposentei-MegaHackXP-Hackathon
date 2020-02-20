using System;
using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class TrailMap : IEntityTypeConfiguration<Trail>
    {
        public void Configure(EntityTypeBuilder<Trail> builder)
        {
            builder.ToTable("Trails");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Reward).IsRequired();
            builder.HasOne(p => p.TrailType).WithMany(b => b.Trails).HasForeignKey(p => p.TypeID);

        }
    }
}
