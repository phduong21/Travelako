
using FT.Travelako.Common.BaseInterface;
using FT.Travelako.Common.BaseModels;

namespace FT.Travelako.Common.BaseImplementation
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
