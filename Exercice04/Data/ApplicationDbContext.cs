using Exercice04.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice04.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dragon> Dragons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:m2idotnet.database.windows.net,1433;Initial Catalog=BDDAntho;Persist Security Info=False;User ID=m2iadmin;Password=p@ssword1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int dernierIndex = 0;
            var listeDragons = new List<Dragon>()
            {
                new Dragon { Id = ++dernierIndex, Nom = "Drogon", Age = 6, Description = "Le favori des dragons"},

                new Dragon { Id= ++dernierIndex, Nom = "Viserion", Age = 6, Description = "Le dragon mort vivant"},

                new Dragon { Id= ++dernierIndex, Nom = "Rhaegal", Age = 6, Description = "Le premier dragon a mourir"}
            };

            modelBuilder.Entity<Dragon>().HasData(listeDragons);
        }
    }
}
