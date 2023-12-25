using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiBaseController
    {
        public UserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
         
        }

        [HttpGet]
        public async Task<GenericAPIResponse> GetAllTravel([FromRoute] GetUserRequestDTO? model)
        {
            return await ExecutionService<GetUserRequestDTO, GetUserService>(model);
        }


        [HttpGet("getAllUser")]
        public async Task<GenericAPIResponse> GetTravel([FromRoute] GetUserRequestDTO? model)
        {
            return await ExecutionService<GetUserRequestDTO, GetUserService>(model);
        }
    }
}
