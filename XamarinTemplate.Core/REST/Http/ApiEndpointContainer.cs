using XamarinTemplate.Core.REST.Enums;

namespace XamarinTemplate.Core.REST.Http
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
