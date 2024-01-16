using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
