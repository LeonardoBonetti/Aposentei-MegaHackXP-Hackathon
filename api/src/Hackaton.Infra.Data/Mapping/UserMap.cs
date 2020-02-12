using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hackaton.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder){
            
            builder.ToTable("User");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(c => c.Password).isRequired().HasMaxLength(32);
            builder.Property(c => c.Email).HasMaxLength(256);
        }
    }
}