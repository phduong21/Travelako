using FT.Travelako.WebAPI.Base.Models;
using FT.Travelako.WebAPI.Models;

namespace FT.Travelako.WebAPI.Services.IServices
{
    public interface IGatewayService
    {
        Task<GenericAPIResponse> ExecuteAsync(GenericAPIRequest request);
    }
}
