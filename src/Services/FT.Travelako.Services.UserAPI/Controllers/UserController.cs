using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.UserAPI.Filter;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.TravelAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ApiBaseController
    {
        public UserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
         
        }

        #region CREATE
        [HttpPost]
        [AllowAnonymous]
        public async Task<GenericAPIResponse> CreateUser([FromBody] CreateUserRequest model)
        {
            return await ExecutionService<CreateUserRequest, CreateUserService>(model);
        }
        #endregion

        #region GET
        [HttpGet("GetUserById")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        public async Task<GenericAPIResponse> GetUserById([FromQuery] GetUserRequest model)
        {
            return await ExecutionService<GetUserRequest, GetUserService>(model);
        }


        [HttpGet("GetAllUser")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "administrator")]
        public async Task<GenericAPIResponse> GetTravel([FromRoute] GetAllUserRequest? model)
        {
            return await ExecutionService<GetAllUserRequest, GetAllUserService>(model);
        }

        #endregion

        #region PUT
        [HttpPut]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business")]
        public async Task<GenericAPIResponse> UpdateUserById([FromBody] UpdateUserRequest model)
        {
            return await ExecutionService<UpdateUserRequest, UpdateUserService>(model);
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business")]
        public async Task<GenericAPIResponse> DeleteUserById([FromQuery] DeleteUserRequest model)
        {
            return await ExecutionService<DeleteUserRequest, DeleteUserService>(model);
        }
        #endregion

        [HttpGet]
        [Route("getallbusinessuser")]
        public async Task<GenericAPIResponse> GetAllBusinessUser()
        {
            return await ExecutionService<DefaultRequest, GetBusinessUserService>();
        }
    }
}
