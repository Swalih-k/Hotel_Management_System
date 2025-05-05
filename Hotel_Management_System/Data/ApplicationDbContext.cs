using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<ROOM> Rooms { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Food> foods { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Review> reviews { get; set; }

    }
}
