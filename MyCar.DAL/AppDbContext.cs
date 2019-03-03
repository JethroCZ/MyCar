using Microsoft.EntityFrameworkCore;
using MyCar.DAL.Entities;

namespace MyCar.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> CarsTable { get; set; }

        public DbSet<Gasoline> GasolineTable { get; set; }

        public DbSet<User> UsersTable { get; set; }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyCar-db;Trusted_Connection=True;Integrated Security = true;");
        }
    }
}