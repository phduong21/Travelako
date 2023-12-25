using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.TravelAPI.Models.DTOs;
using FT.Travelako.Services.TravelAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ApiBaseController
    {
        public TravelController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
         
        }

        [HttpGet]
        public async Task<GenericAPIResponse> GetAllTravel([FromRoute] GetTravelRequestDTO? model)
        {
            return await ExecutionService<GetTravelRequestDTO, GetTravelService>(model);
        }


        [HttpGet("getAllTravel")]
        public async Task<GenericAPIResponse> GetTravel([FromRoute] GetTravelRequestDTO? model)
        {
            return await ExecutionService<GetTravelRequestDTO, GetTravelService>(model);
        }
    }
}
