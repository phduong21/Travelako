using FT.Travelako.Services.Authentication.Base.Interface;
using FT.Travelako.Services.Authentication.Base.Models;

namespace FT.Travelako.Services.Authentication.Base.Implementation
{
    public abstract class BaseExecutionService<R> : IBaseExecutionService where R : IBaseRequestModel
    {
        public BaseExecutionService()
        {
            
        }

        public virtual Task<GenericAPIResponse> ExecuteApi(R requestModel)
        {
            return null;
        }
    }
}
