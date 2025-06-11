using KatalogProduktow.Models;

namespace KatalogProduktow.Service.Interface
{
    public interface IHomeService
    {
        Task<List<Produkt>> PobierzProduktyAsync();
        Task DodajProduktAsync(Produkt produkt);
        Task<Produkt> PobierzProduktAsync(int id);
        Task AktualizujProduktAsync(Produkt produkt);
        Task UsunProduktAsync(int id);

    }
}
