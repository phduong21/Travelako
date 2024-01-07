using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.UserAPI.Models.Requests
{
    public class DeleteUserRequest : IBaseRequestModel
    {
        public string Id { get; set; }
    }
}
