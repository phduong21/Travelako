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
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, ITravelService travelService, IUserService userService)
        {
            _logger = logger;
            _travelService = travelService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var allUser = await _userService.GetAllUsers();
            var user = await _userService.GetUserInformation("duong123");
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
