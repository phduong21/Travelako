using FT.Travelako.UI.Models.Travels;
using FT.Travelako.UI.Models.Travels.ViewModel;
using FT.Travelako.UI.Models.Users;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;

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
            if (travels != null && travels.result.Any())
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
                        
                    }
                    var tests = await _userService.GetAllBusinessUsers();
                    var businessUser = (await _userService.GetAllBusinessUsers()).FirstOrDefault(x => x.Id.ToLower() == travel.result.createdBy.ToLower());
                    if (businessUser != null)
                    {
                        travelViewModel.Author = businessUser;
                    }


                    var recentTravels = await _travelService.GetTravels();
                    if (recentTravels != null && recentTravels.result != null && recentTravels.result.Any())
                    {
                        var travels = recentTravels.result.Where(x => x.id != id).Select(x => new TravelDetailModel
                        {
                            title = x.title,
                            description = x.description,
                            thumbnail = x.thumbnail,
                            images = x.images,
                            content = x.content,
                            province = x.province,
                            location = x.province,
                            tag = x.tag,
                            status = x.status,
                            hotelTitle = x.hotelTitle,
                            hotelPrice = x.hotelPrice,
                            trafficType = x.trafficType,
                            id = x.id,
                            createdBy = x.createdBy,
                            createdDate = x.createdDate,
                            lastModifiedBy = x.lastModifiedBy,
                            lastModifiedDate = x.lastModifiedDate
                        });
                        if(travels != null && travels.Any())
                        {
                            travelViewModel.RecentTravels.result = travels.ToList();
                        }
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