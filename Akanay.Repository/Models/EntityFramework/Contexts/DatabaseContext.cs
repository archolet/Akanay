using Akanay.Core.Entities.Models.CustomUser;
using Akanay.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Akanay.Repository.Models.EntityFramework.Contexts
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set;}

   
        
        
        
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }







    }
}
