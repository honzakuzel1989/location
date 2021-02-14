using System.Net.Http;

namespace location.Core.Services
{
    public interface IHttpClientProvider
    {
        HttpClient Get();
    }
}