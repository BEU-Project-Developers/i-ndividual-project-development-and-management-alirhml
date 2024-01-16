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
            optionsBuilder.UseSqlServer("Data Source=SQL8006.site4now.net;Initial Catalog=db_aa41a1_alirahimli;User Id=db_aa41a1_alirahimli_admin;Password=Ali123@Ali");
        }
    }
}
