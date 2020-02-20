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
            builder.HasData(
                new Trail() { Id = 1, Description = "Desc Trilha 1", Title = "Trila 1", Reward = 1, CreateAt = DateTime.Now, TypeID = 1 },
                new Trail() { Id = 2, Description = "Desc Trilha 2", Title = "Trila 2", Reward = 1, CreateAt = DateTime.Now, TypeID = 1 }

            );

        }
    }
}
