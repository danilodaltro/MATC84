using MATC84.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace MATC84.Persistence.Context
{
    public class MATC84Context : DbContext
    {
        public MATC84Context(DbContextOptions<MATC84Context> options) : base(options)
        {

        }
        public DbSet<Seminario> Seminario { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Pessoa>().HasAlternateKey(p => p.Matricula);
        }
    }
}