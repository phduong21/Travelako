using FT.Travelako.UI.Models.Users.ViewModel;
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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(SignUpVM model)
        {
            // Perform registration logic here
            // For simplicity, let's assume registration is successful

            // Redirect to a thank you page or login page
            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
