using System.Net.Http;
using CoddoTech.Portable.RestClient.Interfaces;
using Xamarin.Android.Net;

namespace XamarinTemplate.Android.Base.Modules
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient New()
        {
            return new HttpClient(new AndroidClientHandler());
        }
    }
}