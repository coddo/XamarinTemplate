using XamarinTemplate.Core.Base.REST.Enums;

namespace XamarinTemplate.Core.Base.REST.Http
{
    public class ApiEndpointContainer
    {
        public ApiEndpointContainer(string url, HttpMethod method)
        {
            Url = url;
            Method = method;
        }

        public string Url { get; set; }

        private HttpMethod Method { get; }
    }
}
