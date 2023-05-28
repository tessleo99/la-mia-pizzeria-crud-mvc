using LaMiaPizzeriaNew.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaNew.Database
{
    public class PizzaContext : DbContext
    {
        public DbSet<GustiPizza> GustiPizza { get; set; }
        public DbSet<PizzaCategory> PizzaCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFPizzeria;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
