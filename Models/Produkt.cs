namespace KatalogProduktow.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        
        public string  Nazwa { get; set; }

        public double Cena { get; set; }

        public string Kategoria { get; set; }
        public string Opis { get; set; }
    }
}
