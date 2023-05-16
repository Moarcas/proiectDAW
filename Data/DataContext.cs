using proiectDAW.Models;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class DataContext : DbContext {

        // Aici decalar tabelele
        public DbSet<User> Users { get; set; } 
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Aici pun relatiile intre tabele
        }
    }
}
    