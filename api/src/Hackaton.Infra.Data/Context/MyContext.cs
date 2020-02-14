using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Hackaton.Infra.Data.Mapping;

namespace Hackaton.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TrailEntity> Trails { get; set; }
        public DbSet<TrailTypeEntity> TrailTypes { get; set; }
        public DbSet<QuizTrailEntity> QuizTrail { get; set; }
        public DbSet<TextTrailEntity> TextTrail { get; set; }
        public DbSet<YoutubeTrailEntity> YoutubeTrail { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<TrailEntity>(new TrailMap().Configure);
            modelBuilder.Entity<TrailTypeEntity>(new TrailTypeMap().Configure);
            modelBuilder.Entity<QuizTrailEntity>(new QuizTrailMap().Configure);
            modelBuilder.Entity<TextTrailEntity>(new TextTrailMap().Configure);
            modelBuilder.Entity<YoutubeTrailEntity>(new YoutubeTrailMap().Configure);

        }
    }
}