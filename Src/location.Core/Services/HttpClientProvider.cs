using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace location.Core.Services
{
    public class HttpClientProvider : IHttpClientProvider, IDisposable
    {
        private readonly HttpClient httpClient;
        private bool disposedValue;

        public HttpClientProvider()
        {
            httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.UserAgent.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("curl", "7.68.0"));
            httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
            httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));
        }

        public HttpClient Get()
        {
            return httpClient;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
