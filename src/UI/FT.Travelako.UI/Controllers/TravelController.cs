using FT.Travelako.UI.Models;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FT.Travelako.UI.Controllers
{
    public class TravelController : Controller
    {
        private readonly ILogger<TravelController> _logger;
        private readonly ITravelService _travelService;

        public TravelController(ILogger<TravelController> logger, ITravelService travelService)
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

        [Route("travel/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
			if(!string.IsNullOrEmpty(id))
            {
				var travel = await _travelService.GetTravelDetail(id);
				if (travel != null && travel.result != null)
				{
					var travelModel = travel.result;
					ViewBag.Title = travelModel?.title;
					return View(travelModel);
				}
			}
            return View("Error");
        }
    }
}
