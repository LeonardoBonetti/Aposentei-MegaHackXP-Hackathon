using Hackaton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Hackaton.Infra.Data.Mapping;

namespace Hackaton.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<QuestionEntity>(new QuestionMap().Configure);
            modelBuilder.Entity<AnswerEntity>(new AnswerMap().Configure);

        }
    }
}