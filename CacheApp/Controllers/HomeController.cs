using CacheApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace CacheApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCacheService _memoryCacheService;
        public HomeController(ILogger<HomeController> logger, IMemoryCacheService memoryCacheService)
        {
            _logger = logger;
            _memoryCacheService = memoryCacheService;
        }

        public IActionResult Index()
        {
            MemoryCacheEntryOptions entryOptions = _memoryCacheService.GetEntryOptions(1024, CacheItemPriority.High, 3, 20);
           
            _memoryCacheService.Set("entry","EntryValue",entryOptions);

            var value = _memoryCacheService.Get("entry");
            _memoryCacheService.Remove("entry");
            value = _memoryCacheService.Get("entry");
            return View();
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
