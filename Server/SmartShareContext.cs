using Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace Server
{
    public class SmartShareContext : DbContext
    {
        public DbSet<FileRequest> FilesIn { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileObject>()
                .HasAlternateKey(t => t.Id)
                .HasName("alternatekey_id");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=127.0.0.1;port=5432;database=Server;userid=postgres;password=bondstone");
        }
    }

}