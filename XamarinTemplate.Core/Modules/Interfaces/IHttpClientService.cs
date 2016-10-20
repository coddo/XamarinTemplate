using System.Net.Http;

namespace XamarinTemplate.Core.Modules.Interfaces
{
    public interface IHttpClientService
    {
        HttpClient GetNativeHttpClientInstance();
    }
}
