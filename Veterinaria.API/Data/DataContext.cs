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
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Pet> Pets { get; set; }    
        public DbSet<ServiceType>  ServiceTypes { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Agenda>Agendas { get; set; }   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
