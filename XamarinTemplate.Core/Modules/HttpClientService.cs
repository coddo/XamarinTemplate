using System.Net.Http;
using ModernHttpClient;
using XamarinTemplate.Core.Modules.Interfaces;

namespace XamarinTemplate.Core.Modules
{
    public class HttpClientService : IHttpClientService
    {
        public HttpClient GetNativeHttpClientInstance()
        {
            return new HttpClient(new NativeMessageHandler());
        }
    }
}
