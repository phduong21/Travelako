using System.ComponentModel.DataAnnotations;
using static FT.Travelako.Common.Utility.StaticData;

namespace FT.Travelako.Common.BaseModels
{
    public class GenericAPIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; } = string.Empty;
        public object Data { get; set; }
        public string AccessToken { get; set; } = string.Empty;
    }
}
