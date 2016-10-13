using System.Net.Http;

namespace XamarinTemplate.Core.Services.Interfaces
{
    public interface IHttpClientService
    {
        HttpClient GetNativeHttpClientInstance();
    }
}
