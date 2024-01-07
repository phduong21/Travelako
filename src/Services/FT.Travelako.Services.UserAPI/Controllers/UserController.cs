using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.UserAPI.Models.Requests;
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

        #region CREATE
        [HttpPost]
        public async Task<GenericAPIResponse> CreateUser([FromBody] CreateUserRequest model)
        {
            return await ExecutionService<CreateUserRequest, CreateUserservice>(model);
        }
        #endregion

        #region GET
        [HttpGet]
        public async Task<GenericAPIResponse> GetUserById([FromQuery] GetUserRequest model)
        {
            return await ExecutionService<GetUserRequest, GetUserService>(model);
        }


        //[HttpGet("getAllUser")]
        //public async Task<GenericAPIResponse> GetTravel([FromRoute] GetUserRequestDTO? model)
        //{
        //    return await ExecutionService<GetUserRequestDTO, GetUserService>(model);
        //}

        #endregion

        #region PUT
        [HttpPut]
        public async Task<GenericAPIResponse> UpdateUserById([FromBody] UpdateUserRequest model)
        {
            return await ExecutionService<UpdateUserRequest, UpdateUserService>(model);
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public async Task<GenericAPIResponse> DeleteUserById([FromQuery] DeleteUserRequest model)
        {
            return await ExecutionService<DeleteUserRequest, DeleteUserService>(model);
        }
        #endregion

    }
}
