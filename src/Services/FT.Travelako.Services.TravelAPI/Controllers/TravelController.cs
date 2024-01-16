using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.TravelAPI.Models.DTOs;
using FT.Travelako.Services.TravelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.TravelAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TravelController : ApiBaseController
	{
		public TravelController(IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}

		[HttpGet("GetTravel")]
		public async Task<GenericAPIResponse> GetTravel([FromQuery] GetTravelRequestDTO? model)
		{
			return await ExecutionService<GetTravelRequestDTO, GetTravelService>(model);
		}

		[HttpPost("CreateTravel")]
		public async Task<GenericAPIResponse> CreateTravel([FromBody] CreateTravelRequestDTO? model)
		{
			return await ExecutionService<CreateTravelRequestDTO, CreateTravelService>(model);
		}

		[HttpDelete("DeleteTravel")]
		public async Task<GenericAPIResponse> DeleteTravel([FromBody] DeleteTravelRequestDTO? model)
		{
			return await ExecutionService<DeleteTravelRequestDTO, DeleteTravelService>(model);
		}

		[HttpPut("UpdateTravel")]
		public async Task<GenericAPIResponse> UpdateTravel([FromBody] UpdateTravelRequestDTO? model)
		{
			return await ExecutionService<UpdateTravelRequestDTO, UpdateTravelService>(model);
		}
	}
}