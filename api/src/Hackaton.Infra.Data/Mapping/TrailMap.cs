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
            builder.HasOne(p => p.TrailType).WithMany(b => b.Trails).HasForeignKey(p => p.TypeID);


            builder.Property(p => p.Reward).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired();

            builder.HasData(
                new Trail() { Id = 1, Title = "Title Text", Description = "Text", Reward = 10, TypeID = 1, CreateAt = DateTime.Now },
                new Trail() { Id = 2, Title = "Title Video 2", Description = "Video 2", Reward = 10, TypeID = 2, CreateAt = DateTime.Now }
            );
        }
    }
}
