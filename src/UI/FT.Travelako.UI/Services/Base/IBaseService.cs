using FT.Travelako.Common.BaseModels;

namespace FT.Travelako.UI.Services.Base
{
    public interface IBaseService
    {
        Task<GenericAPIResponse> ExecuteAsync(GenericAPIRequest request);
    }
}
