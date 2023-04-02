using Akanay.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Akanay.Repository.Models.EntityFramework.Contexts
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Akanay;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }


    }
}
