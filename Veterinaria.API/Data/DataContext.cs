using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Veterinaria.Shared.Entities;

namespace Veterinaria.API.Data
{
    /*La clase DataContext hereda de DbContext*/
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { 
            
        }

        /*Se registra las entidades con DbSet*/
        public DbSet<Owner>Owners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
