using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.UserAPI.Models.Requests
{
    public class GetUserRequest : IBaseRequestModel
    {
        public string Id { get; set; }
    }
}
