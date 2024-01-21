using FT.Travelako.Common.BaseInterface;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.UserAPI.Filter;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.UserAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonalizationController : ApiBaseController
    {
        public PersonalizationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPut]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        public async Task<GenericAPIResponse> UpdateUserPersonalize(PersonalizeRequest model)
        {
            return await ExecutionService<PersonalizeRequest, UpdateUserPersonalizeService>(model);
        }

        [HttpGet]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        public async Task<GenericAPIResponse> GetUserPersonalize([FromQuery] GetPersonalizeRequest model)
        {
            return await ExecutionService<GetPersonalizeRequest, GetPersonalizeUserService>(model);
        }
    }
}

