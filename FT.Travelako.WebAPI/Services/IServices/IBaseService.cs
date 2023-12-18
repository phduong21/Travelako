using FT.Travelako.WebAPI.Models.Common;

namespace FT.Travelako.WebAPI.Services.IServices
{
    public interface IBaseService
    {
        Task<GenericAPIResponse> ExecuteAsync(GenericAPIRequest request);
    }
}
