namespace FT.Travelako.UI.Base
{
    public interface IBaseApiClient
    {
        Task<List<T>> GetListAsync<T>(string requestUri, bool requiredLogin = false, string baseApiUrl = null);

        Task<T> GetAsync<T>(string requestUri, bool requiredLogin = false, string baseApiUrl = null);

        Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest requestContent, bool requiredLogin = true, string baseApiUrl = null);

        Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest requestContent, bool requiredLogin = true, string baseApiUrl = null);

        Task<T> DeleteAsync<T>(string requestUri, bool requiredLogin = false, string baseApiUrl = null);
    }
}
