using CollectionApp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.api.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }

        public DbSet<UserPhoto> UserPhotos { get; set; }

        public DbSet<CollectionGundam> CollectionGundams { get; set; }

        public DbSet<CollectionGundamPhoto> CollectionGundamPhotos { get; set; }
    }
}