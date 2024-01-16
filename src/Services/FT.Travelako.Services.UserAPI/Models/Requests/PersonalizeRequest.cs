using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.UserAPI.Models.Requests
{
    public class PersonalizeRequest : IBaseRequestModel
    {
        public string Location { get; set; }
    }
}
