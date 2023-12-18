using FT.Travelako.WebAPI.Models.Common;
using FT.Travelako.WebAPI.Services.IServices;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using static FT.Travelako.WebAPI.Utility.StaticData;

namespace FT.Travelako.WebAPI.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
             _httpClientFactory = httpClientFactory;
        }

        public async Task<GenericAPIResponse> ExecuteAsync(GenericAPIRequest request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("TravelakoAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                //token

                message.RequestUri = new Uri(request.Url);
                if (request.Data is not null)
                {
                    message.Content = new StringContent(
                        content: JsonConvert.SerializeObject(request.Data),
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                }

                HttpResponseMessage? response = null;

                switch (request.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.PATCH:
                        message.Method = HttpMethod.Patch;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                response = await client.SendAsync(message);

                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case System.Net.HttpStatusCode.MethodNotAllowed:
                        return new() { IsSuccess = false, Message = "Method not allowed" };
                    case System.Net.HttpStatusCode.UnsupportedMediaType:
                        return new() { IsSuccess = false, Message = "Unsupported media type" };
                    case System.Net.HttpStatusCode.NotImplemented:
                        return new() { IsSuccess = false, Message = "Not implemented" };
                    default:
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GenericAPIResponse>(content);
                }
            }
            catch (Exception ex)
            {
                return new GenericAPIResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
