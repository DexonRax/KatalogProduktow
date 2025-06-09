using Microsoft.EntityFrameworkCore;

namespace bazaDanych.Models
{
    public class BazaDbContext : DbContext
    {
        public BazaDbContext(DbContextOptions<BazaDbContext> options) : base(options){ }

        public DbSet<Produkt> Produkty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<Produkt>().HasData(
                new Produkt { Id = 1, Nazwa = "A", Cena = 1.99, Opis = "ok", Kategoria = "Spożywcze"},
                new Produkt { Id = 2, Nazwa = "B", Cena = 2.99, Opis = "ek", Kategoria = "Spożywcze" }) ;*/

        }


    }
}
