using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseInterface;
using FT.Travelako.Common.BaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FT.Travelako.Common.Controller
{
    public abstract class ApiBaseController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public ApiBaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public virtual Task<GenericAPIResponse> ExecutionService<R, S>(R request = default)
                                                        where R : IBaseRequestModel
                                                        where S : IBaseExecutionService
        {
            IBaseExecutionService runner = (IBaseExecutionService)ActivatorUtilities.GetServiceOrCreateInstance(_serviceProvider, typeof(S));
            if (runner == null)
            {
                throw new Exception("BaseExecutionService has not defined");
            }

            BaseExecutionService<R> runnerBaseService = (BaseExecutionService<R>)runner;

            return runnerBaseService.ExecuteApi(request);
        }
    }
}
