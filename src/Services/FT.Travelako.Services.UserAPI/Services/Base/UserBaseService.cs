using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseInterface;
using FT.Travelako.Services.UserAPI.Repositories;

namespace FT.Travelako.Services.UserAPI.Services.Base
{
    public class UserBaseService<T> : BaseExecutionService<T> where T : IBaseRequestModel
    {
        protected IUserRepository _userRepository;

        public UserBaseService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
