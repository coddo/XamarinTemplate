using System.Net.Http;
using ModernHttpClient;
using XamarinTemplate.Core.Base.Modules.Interfaces;

namespace XamarinTemplate.Core.Base.Modules
{
    public class HttpClientService : IHttpClientService
    {
        public HttpClient GetNativeHttpClientInstance()
        {
            return new HttpClient(new NativeMessageHandler());
        }
    }
}
