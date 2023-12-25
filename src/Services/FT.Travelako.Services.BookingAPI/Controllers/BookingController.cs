using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.BookingAPI.Models.DTOs;
using FT.Travelako.Services.BookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ApiBaseController
    {
        public BookingController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
         
        }

        [HttpGet]
        public async Task<GenericAPIResponse> GetCoupon([FromRoute] GetBookingRequestDTO? model)
        {
            return await ExecutionService<GetBookingRequestDTO, GetBookingService>(model);
        }


        [HttpGet("GetBookingAll")]
        public async Task<GenericAPIResponse> GetCouponAll([FromRoute] GetBookingRequestDTO? model)
        {
            return await ExecutionService<GetBookingRequestDTO, GetBookingService>(model);
        }
    }
}
