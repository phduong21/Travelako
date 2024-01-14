using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.Authentication.Model;
using FT.Travelako.Services.Authentication.Model.Request_Model;
using FT.Travelako.Services.Authentication.Services.Mediator_Service;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<GenericAPIResponse> Login([FromBody] LoginUserRequest model)
        {
            return await ExecutionService<LoginUserRequest, LoginService>(model);
        }
           

        [AllowAnonymous]
        [HttpGet("Ping")]
        public  IActionResult Ping()
        {
            return Ok("Pong");
        }

    }
}
