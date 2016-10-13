namespace XamarinTemplate.Models.Response
{
    public static class ResponseFactory
    {
        public static XamarinTemplate.Models.Response.Response CreateResponse(bool succeeded, int errorCode)
        {
            return new XamarinTemplate.Models.Response.Response(succeeded, errorCode);
        }

        public static XamarinTemplate.Models.Response.Response CreateResponse(bool succeeded, ResponseCode errorCode)
        {
            return new XamarinTemplate.Models.Response.Response(succeeded, errorCode);
        }

        public static Response<T> CreateResponse<T>(bool succeeded, int errorCode, T data = null) where T : class
        {
            return new Response<T>(succeeded, errorCode, data);
        }

        public static Response<T> CreateResponse<T>(bool succeeded, ResponseCode errorCode, T data = null) where T : class
        {
            return new Response<T>(succeeded, errorCode, data);
        }
    }
}