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
        public DbSet<TextTrail> TextTrails { get; set; }
        public DbSet<VideoTrail> VideoTrails { get; set; }
        public DbSet<QuizTrail> QuizTrails { get; set; }
        public DbSet<QuizAnswersTrail> QuizAnswersTrails { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Trail>(new TrailMap().Configure);
            modelBuilder.Entity<TrailType>(new TrailTypeMap().Configure);
            modelBuilder.Entity<TextTrail>(new TextTrailMap().Configure);
            modelBuilder.Entity<VideoTrail>(new VideoTrailMap().Configure);
            modelBuilder.Entity<QuizTrail>(new QuizTrailMap().Configure);
            modelBuilder.Entity<QuizAnswersTrail>(new QuizAnswersTrailMap().Configure);
        }
    }
}