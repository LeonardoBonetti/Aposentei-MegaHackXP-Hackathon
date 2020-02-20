using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Password).IsRequired().HasMaxLength(32);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Coins).HasDefaultValue(0);
            builder.HasOne(p => p.Trail).WithMany(x => x.Users).HasForeignKey(p => p.TrailID);

        }
    }
}