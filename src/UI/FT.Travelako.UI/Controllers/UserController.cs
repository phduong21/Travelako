using FT.Travelako.Common.Entities;
using FT.Travelako.Common.Models;
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
        public async Task<IActionResult> Register(SignUpVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            if (!Enum.TryParse(model.Role, out UserRoles role))
            {
                ModelState.AddModelError(string.Empty, "Unexpected Role Value.");
                return View("Index", model);
            }

            // Your registration logic here
            var newUser = await _userService.CreateUser(new Models.Users.CreateUserModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Email = model.Email,
                Address = model.Address,
                Password = model.Password,
                Role = role
            });

            bool registrationSuccess = true;   //temp

            if (registrationSuccess)
            {
                //var accessToken = await GetAccessTokenAsync("your_client_id", "your_client_secret");

                //HttpContext.Session.SetString("AccessToken", accessToken);

                return Redirect("/Home/Index");
            }

            ModelState.AddModelError(string.Empty, "Registration failed. Please check your information.");
            return View("Index", model);
        }
    }
}
