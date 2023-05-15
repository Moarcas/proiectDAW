using proiectDAW.Models;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class DataContext : DbContext {
        protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration) {
            _configuration = configuration;
        }

        // Aici decalar tabelele
        public DbSet<User> Users { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Aici pun relatiile intre tabele
        }
    }
}
    