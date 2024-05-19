

namespace Core.Contracts
{
    // Contracts defining functionality for singelton services that can be used all over the proj scopes, ex: http request dispatcher class
    public interface IHttpRequestDispatcher : IDisposable
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, object data);
        Task<HttpResponseMessage> PutAsync(string url, object data);
        Task<HttpResponseMessage> DeleteAsync(string url);
    }
}
