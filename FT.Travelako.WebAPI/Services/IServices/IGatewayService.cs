using FT.Travelako.Base.BaseModels;

namespace FT.Travelako.WebAPI.Services.IServices
{
    public interface IGatewayService
    {
        Task<GenericAPIResponse> ExecuteAsync(GenericAPIRequest request);
    }
}
