using FT.Travelako.Common.Entities;
using FT.Travelako.Common.Helpers;
using FT.Travelako.Common.Models;
using FT.Travelako.UI.Models.Users.ViewModel;
using FT.Travelako.UI.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Microsoft.AspNetCore.Authorization;

namespace FT.Travelako.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IAuthenticationService authenService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _authenService = authenService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
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
                return RedirectToAction("Login");
            }

            ModelState.AddModelError(string.Empty, "Registration failed. Please check your information.");
            return View("Index", model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            var login = await _authenService.LoginUser(new Models.Authentication.LoginModel
            {
                Username = model.Username,
                Password = model.Password
            });
            if(login != null && login.Token.Length > 0)
            {
                HttpContext.Session.SetString("AccessToken", login.Token);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Login failed. Please check your information.");

            return View("Login", model);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            var token = _httpContextAccessor.HttpContext?.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(token))
            {
                return View("~/Views/User/Unauthorize.cshtml");
            }
            var userId = JwtHelper.GetClaimValue(token, "id");
            if (string.IsNullOrEmpty(userId))
            {
                return View("~/Views/User/Unauthorize.cshtml");
            }
            var currentUser = await _userService.GetUserInformationById(userId);
            if(currentUser == null)
            {
                return View("~/Views/User/Unauthorize.cshtml");
            }
            string imgPath = "/img/default-profile-img.jpg";
            ViewBag.ImagePath = imgPath;

            return View(currentUser);
        }

        //[AccessTokenAuthorize]
        public async Task<IActionResult> EditUser()
        {
            var userId = JwtHelper.GetClaimValue("", "id");
            if (string.IsNullOrEmpty(userId))
            {
                return View("~/Views/User/Unauthorize.cshtml");
            }
            var currentUser = await _userService.GetUserInformationById(userId);
            if (currentUser == null)
            {
                return View("~/Views/User/Unauthorize.cshtml");
            }
            return View();
        }
    }
}
