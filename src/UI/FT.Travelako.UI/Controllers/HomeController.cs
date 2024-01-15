using FT.Travelako.UI.Models;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FT.Travelako.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITravelService _travelService;

        public HomeController(ILogger<HomeController> logger, ITravelService travelService)
        {
            _logger = logger;
            _travelService = travelService;
        }

        public async Task<IActionResult> Index()
        {
            var travels = await _travelService.GetTravels();
            if(travels != null && travels.result.Any())
                return View(travels);
            else return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("about")]
		public IActionResult AboutUs()
		{
			return View();
		}

		[Route("contact")]
		public IActionResult ContactUs()
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
