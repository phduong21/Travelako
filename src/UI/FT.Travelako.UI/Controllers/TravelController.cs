using FT.Travelako.UI.Models;
using FT.Travelako.UI.Models.Travels.ViewModel;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FT.Travelako.UI.Controllers
{
    public class TravelController : Controller
    {
        private readonly ILogger<TravelController> _logger;
        private readonly ITravelService _travelService;
        private readonly IUserService _userService;

        public TravelController(ILogger<TravelController> logger, ITravelService travelService, IUserService userService)
        {
            _logger = logger;
            _travelService = travelService;
            _userService = userService;
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
			if (!string.IsNullOrEmpty(id))
            {
				var travelViewModel = new TravelDetailViewModel();
				var travel = await _travelService.GetTravelDetail(id);
				if (travel != null && travel.result != null)
				{
                    // update user personalize by token
                    var currentUser = _userService.GetCurrentUser();
                    if (currentUser != null)
                    {
                        await _userService.UpdatePersonalizeUser(new Models.Users.PersonalizeModel
                        {
                            Id = currentUser.Id,
                            Location = travel.result.location
                        });
						travelViewModel.Author = await _userService.GetUserInformationById(currentUser.Id);
					}

                    var recentTravels = await _travelService.GetTravels();
                    if (recentTravels != null && recentTravels.result.Any())
                    {
                        travelViewModel.RecentTravels = recentTravels;
                    }

                    travelViewModel.TravelDetail = travel.result;
					ViewBag.Title = travelViewModel.TravelDetail?.title;
					return View(travelViewModel);
				}
			}
            return View("NotFound");
        }
    }
}
