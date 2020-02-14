using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Password).IsRequired().HasMaxLength(32);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(256);
            builder.Property(c => c.Coins).HasDefaultValue(0);
            builder.Property(c => c.TrailID);
        }
    }
}