using BookingSystemApi.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Database.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<Resource> Resource { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>(o =>
            {
                o.Property<int>("Id");
                o.HasKey("Id");
            });
        }
    }
}
