using Newtonsoft.Json;
using NuGet.Common;
using System.Text;

namespace FT.Travelako.UI.Base
{
    public class BaseApiClient : IBaseApiClient
    {
        private readonly string _baseUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string token;
        public BaseApiClient(string baseUrl = null, IHttpContextAccessor httpContextAccessor = null)
        {
            _baseUrl = baseUrl;
            _httpContextAccessor = httpContextAccessor;
            token = _httpContextAccessor.HttpContext.Session.GetString("AccessToken");
        }

        public async Task<List<T>> GetListAsync<T>(string requestUri, bool requiredLogin = false, string baseApiUrl = null)
        {
            string url = string.IsNullOrWhiteSpace(baseApiUrl) ? $"{_baseUrl}/{requestUri}" : $"{baseApiUrl}/{requestUri}";
            if (!string.IsNullOrWhiteSpace(url))
            {
                using (var client = new HttpClient())
                {
                    if (requiredLogin)
                    {
                        // var token = await HttpContext.GetTokenAsync("access_token");
                        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var data = (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                        return data;
                    }
                }
            }
            return default;
        }

        public async Task<T> GetAsync<T>(string requestUri, bool requiredLogin = false, string baseApiUrl = null)
        {
            string url = string.IsNullOrWhiteSpace(baseApiUrl) ? $"{_baseUrl}/{requestUri}" : $"{baseApiUrl}/{requestUri}";
            if (!string.IsNullOrWhiteSpace(url))
            {
                using (var client = new HttpClient())
                {
                    if (requiredLogin)
                    {
                        // var token = await HttpContext.GetTokenAsync("access_token");
                        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await GetDataResponseAsync<T>(response);
                    }
                }
            }
            return default;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest requestContent, bool requiredLogin = true, string baseApiUrl = null)
        {
            string url = string.IsNullOrWhiteSpace(baseApiUrl) ? $"{_baseUrl}/{requestUri}" : $"{baseApiUrl}/{requestUri}";
            if (!string.IsNullOrWhiteSpace(url))
            {
                using (var client = new HttpClient())
                {
                    StringContent httpContent = null;
                    if (requestContent != null)
                    {
                        var json = JsonConvert.SerializeObject(requestContent);
                        httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    }
                    if (requiredLogin)
                    {
                        // var token = await HttpContext.GetTokenAsync("access_token");
                        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.PostAsync(url, httpContent);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await GetDataResponseAsync<TResponse>(response);
                    }
                }
            }
            return default;
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest requestContent, bool requiredLogin = true, string baseApiUrl = null)
        {
            string url = string.IsNullOrWhiteSpace(baseApiUrl) ? $"{_baseUrl}/{requestUri}" : $"{baseApiUrl}/{requestUri}";
            if (!string.IsNullOrWhiteSpace(url))
            {
                using (var client = new HttpClient())
                {
                    StringContent httpContent = null;
                    if (requestContent != null)
                    {
                        var json = JsonConvert.SerializeObject(requestContent);
                        httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    }
                    if (requiredLogin)
                    {
                        // var token = await HttpContext.GetTokenAsync("access_token");
                        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.PutAsync(url, httpContent);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await GetDataResponseAsync<TResponse>(response);
                    }
                }
            }
            return default;
        }

        public async Task<T> DeleteAsync<T>(string requestUri, bool requiredLogin = false, string baseApiUrl = null)
        {
            string url = string.IsNullOrWhiteSpace(baseApiUrl) ? $"{_baseUrl}/{requestUri}" : $"{baseApiUrl}/{requestUri}";
            if (!string.IsNullOrWhiteSpace(url))
            {
                using (var client = new HttpClient())
                {
                    if (requiredLogin)
                    {
                        // var token = await HttpContext.GetTokenAsync("access_token");
                        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.DeleteAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await GetDataResponseAsync<T>(response);
                    }
                }
            }
            return default;
        }

        private async Task<T> GetDataResponseAsync<T>(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(body);
            return data;
        }
    }
}
