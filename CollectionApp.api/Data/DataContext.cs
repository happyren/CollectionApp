using CollectionApp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserPhoto> UserPhotos { get; set; }

        public DbSet<CollectionGundam> CollectionGundams { get; set; }

        public DbSet<CollectionGundamPhoto> CollectionGundamPhotos { get; set; }

        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>().HasKey(k => new {k.LikerId, k.LikeeId});

            modelBuilder.Entity<Like>().HasOne(u => u.Liker).WithMany(u => u.Likees)
                .HasForeignKey(u => u.LikerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>().HasOne(c => c.Likee).WithMany(c => c.Likers)
                .HasForeignKey(c => c.LikeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}