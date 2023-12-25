using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.UserAPI.Models.DTOs
{
    public class GetUserRequestDTO : IBaseRequestModel
    {
        public string? Code { get; set; }
    }
}
