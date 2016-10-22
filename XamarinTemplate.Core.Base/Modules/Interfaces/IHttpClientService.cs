using System.Net.Http;

namespace XamarinTemplate.Core.Base.Modules.Interfaces
{
    public interface IHttpClientService
    {
        HttpClient GetNativeHttpClientInstance();
    }
}
