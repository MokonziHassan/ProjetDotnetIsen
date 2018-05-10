using Isen.DotNet.Library.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Isen.DotNet.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        // 1 - Préciser les DbSet
        public DbSet<pointDinteret> piCollection { get;set; }
        public DbSet<categorie> categorieCollection { get;set; }
        public DbSet<adresse> adresseCollection { get;set; }
        public DbSet<commune> communeCollection { get;set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // 2 - Configurer les mappings tables / classes
            

            
        }
    }
}