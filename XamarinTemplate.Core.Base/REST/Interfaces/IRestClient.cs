using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinTemplate.Core.Base.REST.Enums;
using XamarinTemplate.Models.Response;

namespace XamarinTemplate.Core.Base.REST.Interfaces
{
    public interface IRestClient
    {
        Task<TOutput> ExecuteGetAsync<TOutput>(ApiEndpoint apiEndpoint, IDictionary<string, string> parameters = null,
            IDictionary<string, string> headers = null) where TOutput : class, new();

        Task<Response> ExecutePostAsync(ApiEndpoint apiEndpoint, object input, IDictionary<string, string> parameters = null, 
            IDictionary<string, string> headers = null);

        Task<TOutput> ExecutePostAsync<TInput, TOutput>(ApiEndpoint apiEndpoint, TInput input, IDictionary<string, string> parameters = null, 
            IDictionary<string, string> headers = null)
            where TInput : class where TOutput : class, new();

        Task<TOutput> ExecutePostFormUrlEncodedAsync<TOutput>(ApiEndpoint apiEndpoint, string username, string password,
            IDictionary<string, string> parameters = null, IDictionary<string, string> headers = null) where TOutput : class, new();
    }
}
