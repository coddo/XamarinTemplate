using XamarinTemplate.Models.Extensions;

namespace XamarinTemplate.Models.Response
{
    public class Response
    {
        public Response()
        {
            StatusCode = ResponseCode.NotSet.ToInt();
        }

        private Response(bool succeeded) : this()
        {
            Succeeded = succeeded;
        }

        internal Response(bool succeeded, int statusCode) : this(succeeded)
        {
            StatusCode = statusCode;
        }

        internal Response(bool succeeded, ResponseCode statusCode) : this(succeeded)
        {
            StatusCode = statusCode.ToInt();
        }

        public bool Succeeded { get; set; }

        public int StatusCode { get; set; }
    }

    public class Response<T> : Response where T : class
    {
        public Response()
        {
            StatusCode = ResponseCode.NotSet.ToInt();
        }

        internal Response(bool succeeded, int statusCode, T data) : base(succeeded, statusCode)
        {
            StatusCode = statusCode;
            Data = data;
        }

        internal Response(bool succeeded, ResponseCode statusCode, T data) : base(succeeded, statusCode)
        {
            StatusCode = statusCode.ToInt();
            Data = data;
        }

        public T Data { get; set; }
    }
}