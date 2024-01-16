using Microsoft.EntityFrameworkCore;
using MyWinFormsApp.model;
namespace MyWinFormsApp.data
{
    public class AppDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database= Sosialv2App; User Id=sa; Password=Password@12345;TrustServerCertificate=True;");
        }
    }
}
