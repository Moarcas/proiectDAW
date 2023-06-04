using proiectDAW.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers{ get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasOne(q => q.user)
                .WithMany()
                .HasForeignKey(q => q.userId);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.user)
                .WithMany()
                .HasForeignKey(a => a.userId);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.question)
                .WithMany()
                .HasForeignKey(a => a.questionId);
        }
    }
}
