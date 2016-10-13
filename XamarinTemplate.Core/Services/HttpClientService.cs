using System.Net.Http;
using ModernHttpClient;
using XamarinTemplate.Core.Services.Interfaces;

namespace XamarinTemplate.Core.Services
{
    public class HttpClientService : IHttpClientService
    {
        public HttpClient GetNativeHttpClientInstance()
        {
            return new HttpClient(new NativeMessageHandler());
        }
    }
}
