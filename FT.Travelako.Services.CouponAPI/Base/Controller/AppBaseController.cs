using FT.Travelako.Services.CouponAPI.Base.Implementation;
using FT.Travelako.Services.CouponAPI.Base.Interface;
using FT.Travelako.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.CouponAPI.Base.Controller
{
    public abstract class AppBaseController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public AppBaseController(IServiceProvider serviceProvider)
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
