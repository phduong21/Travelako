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
            //var allUser = await _userService.GetAllUsers();
            //var user = await _userService.GetUserInformation("duong123");
            //var updateUser = await _userService.UpdateUser(new Models.Users.UpdateUserModel{
            //    Id = "69121893-3AFC-4F92-85F3-40BB5E7C7E29",
            //    FirstName = "duong updated 1601"
            //});
            // await _userService.DeleteUser("4f075e3d-a935-45b2-8667-08dc1526dd2b");

            //var newUser = await _userService.CreateUser(new Models.Users.CreateUserModel
            //{
            //    FirstName = "new user",
            //    LastName = "ln1 1601",
            //    UserName = "duong1289",
            //    Email = "duong1601@test.com",
            //    Address = "21 Duy Tan",
            //    Password = "123",
            //    Role = Common.Models.UserRoles.User
            //});
            //var personalize = await _userService.GetPersonalizeUser("4f075e3d-a935-45b2-8667-08dc1526dd2b");
            //await _userService.UpdatePersonalizeUser(new Models.Users.PersonalizeModel
            //{
            //    Id = "4f075e3d-a935-45b2-8667-08dc1526dd2b",
            //    Location = "Danang"
            //});
            var travels = await _travelService.GetTravels();
            if (travels != null && travels.result.Any())
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
