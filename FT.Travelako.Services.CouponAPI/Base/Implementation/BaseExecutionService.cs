using FT.Travelako.Services.CouponAPI.Base.Interface;
using FT.Travelako.Services.CouponAPI.Models;

namespace FT.Travelako.Services.CouponAPI.Base.Implementation
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
