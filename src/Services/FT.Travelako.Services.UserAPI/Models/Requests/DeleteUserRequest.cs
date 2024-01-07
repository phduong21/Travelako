using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.UserAPI.Models.Requests
{
    public class DeleteUserRequest : IBaseRequestModel
    {
        public Guid Id { get; set; }
    }
}
