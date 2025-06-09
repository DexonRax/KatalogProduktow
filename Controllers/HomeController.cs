using bazaDanych.Models;
using bazaDanych.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bazaDanych.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Katalog()
        {
            var produkty = await _homeService.PobierzProduktyAsync();
            return View(produkty);
        }

        [HttpGet]
        public IActionResult DodajProdukt()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DodajProdukt(Produkt produkt)
        {
            if (ModelState.IsValid)
                await _homeService.DodajProduktAsync(produkt);

            return RedirectToAction("Katalog");
        }

        public async Task<IActionResult> Edytuj(int id)
        {
            var produkt = await _homeService.PobierzProduktAsync(id);
            return View(produkt);
        }

        [HttpPost]
        public async Task<IActionResult> Edytuj(Produkt produkt)
        {
            if (ModelState.IsValid)
                await _homeService.AktualizujProduktAsync(produkt);

            return RedirectToAction("Katalog");
        }

        public async Task<IActionResult> Usun(int id)
        {
            await _homeService.UsunProduktAsync(id);
            return RedirectToAction("Katalog");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
