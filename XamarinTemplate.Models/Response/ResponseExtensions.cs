namespace XamarinTemplate.Models.Response
{
    public static class ResponseExtensions
    {
        public static bool IsSuccessful(this XamarinTemplate.Models.Response.Response response)
        {
            return response != null && response.Succeeded;
        }

        public static bool IsSuccessful<T>(this Response<T> response) where T : class
        {
            return response != null && response.Succeeded && response.Data != null;
        }
    }
}
