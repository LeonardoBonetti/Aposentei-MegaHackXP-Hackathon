using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Hackaton.Infra.Data.Mapping;

namespace Hackaton.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<TrailType> TrailTypes { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Trail>(new TrailMap().Configure);
            modelBuilder.Entity<TrailType>(new TrailTypeMap().Configure);
        }
    }
}