using bazaDanych.Controllers;
using bazaDanych.Models;
using bazaDanych.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace bazaDanych.Service
{
    public class HomeService : IHomeService
    {
        private readonly BazaDbContext _db;

        public HomeService(BazaDbContext db)
        {  _db = db; }

        public async Task<List<Produkt>> PobierzProduktyAsync()
        {
            return await _db.Produkty.ToListAsync();
        }
        public async Task DodajProduktAsync(Produkt produkt)
        {
            _db.Produkty.Add(produkt);
            await _db.SaveChangesAsync();
        }

        public async Task<Produkt> PobierzProduktAsync(int id)
        {
            return await _db.Produkty.FindAsync(id);
        }

        public async Task AktualizujProduktAsync(Produkt produkt)
        {
            _db.Produkty.Update(produkt);
            await _db.SaveChangesAsync();
        }

        public async Task UsunProduktAsync(int id)
        {
            var produkt = await _db.Produkty.FindAsync(id);
            if (produkt != null)
            {
                _db.Produkty.Remove(produkt);
                await _db.SaveChangesAsync();
            }
        }

    }
}
