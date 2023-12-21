using FT.Travelako.Base.BaseInterface;
using FT.Travelako.Base.BaseModels;

namespace FT.Travelako.Base.BaseImplementation
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
