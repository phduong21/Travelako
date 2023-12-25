using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FT.Travelako.Services.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagermentController : ApiBaseController
    {
        public UserManagermentController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Ping()
        {
            return Ok();
        }

    }
}
