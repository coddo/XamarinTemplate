using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinTemplate.Core.Base.Containers;
using XamarinTemplate.Core.Base.REST.Constants;
using XamarinTemplate.Core.Base.REST.Enums;
using XamarinTemplate.Core.Base.REST.Interfaces;
using XamarinTemplate.Models.Constants;
using XamarinTemplate.Models.Response;
using HttpMethod = XamarinTemplate.Core.Base.REST.Enums.HttpMethod;

namespace XamarinTemplate.Core.Base.REST.Http
{
    public class RestClient : IRestClient
    {
        private readonly IDictionary<ApiEndpoint, ApiEndpointContainer> mApiEndpointUrlMappings =
            new Dictionary<ApiEndpoint, ApiEndpointContainer>();

        public RestClient()
        {
            ConfigureMappings();
        }

        #region Public methods

        public async Task<TOutput> ExecuteGetAsync<TOutput>(ApiEndpoint apiEndpoint, IDictionary<string, string> parameters = null,
            IDictionary<string, string> headers = null) where TOutput : class, new()
        {
            if (!HasInternetConnection())
            {
                return null;
            }

            var url = RetrieveUrlFromApiEndpoint(apiEndpoint, parameters);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            using (var client = CoreServices.HtppClientService.GetNativeHttpClientInstance())
            {
                SetupHttpClient(client, headers);

                try
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var stringfiedContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        var deserializedData = !string.IsNullOrWhiteSpace(stringfiedContent) 
                            ? JsonConvert.DeserializeObject<TOutput>(stringfiedContent) 
                            : null;

                        return deserializedData;
                    }
                }
                catch (WebException)
                {
                    CoreServices.NetworkService.SignalServerConnectionDown();
                }
                catch (Exception ex)
                {
                    CoreServices.LoggingService.LogException(ex);
                }
            }

            return null;
        }

        public async Task<Response> ExecutePostAsync(ApiEndpoint apiEndpoint, object input, IDictionary<string, string> parameters = null,
            IDictionary<string, string> headers = null)
        {
            if (!HasInternetConnection())
            {
                return null;
            }

            var url = RetrieveUrlFromApiEndpoint(apiEndpoint, parameters);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            using (var client = CoreServices.HtppClientService.GetNativeHttpClientInstance())
            {
                SetupHttpClient(client, headers);
                try
                {
                    var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(input),
                        Encoding.UTF8, ContentTypeConstants.APPLICATION_JSON)).ConfigureAwait(false);

                    if (response != null)
                    {
                        return ResponseFactory.CreateResponse(response.IsSuccessStatusCode, ResponseCode.SuccessNoData);
                    }
                }
                catch (WebException)
                {
                    CoreServices.NetworkService.SignalServerConnectionDown();
                }
                catch (Exception ex)
                {
                    CoreServices.LoggingService.LogException(ex);
                }
            }

            return ResponseFactory.CreateResponse(false, ResponseCode.ErrorAnErrorOccurred);
        }

        public async Task<TOutput> ExecutePostAsync<TInput, TOutput>(ApiEndpoint apiEndpoint, TInput input,
            IDictionary<string, string> parameters = null, IDictionary<string, string> headers = null) 
            where TInput : class where TOutput : class, new()
        {
            if (!HasInternetConnection())
            {
                return null;
            }

            var url = RetrieveUrlFromApiEndpoint(apiEndpoint, parameters);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            using (var client = CoreServices.HtppClientService.GetNativeHttpClientInstance())
            {
                SetupHttpClient(client, headers);
                try
                {
                    var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(input),
                        Encoding.UTF8, ContentTypeConstants.APPLICATION_JSON)).ConfigureAwait(false);

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var stringfiedContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        var deserializedData = !string.IsNullOrWhiteSpace(stringfiedContent)
                            ? JsonConvert.DeserializeObject<TOutput>(stringfiedContent)
                            : null;

                        return deserializedData;
                    }
                }
                catch (WebException)
                {
                    CoreServices.NetworkService.SignalServerConnectionDown();
                }
                catch (Exception ex)
                {
                    CoreServices.LoggingService.LogException(ex);
                }
            }

            return null;
        }

        public async Task<TOutput> ExecutePostFormUrlEncodedAsync<TOutput>(ApiEndpoint apiEndpoint, string username, string password,
            IDictionary<string, string> parameters = null, IDictionary<string, string> headers = null) where TOutput : class, new()
        {
            if (!HasInternetConnection())
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var url = RetrieveUrlFromApiEndpoint(apiEndpoint, parameters);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            using (var client = CoreServices.HtppClientService.GetNativeHttpClientInstance())
            {
                SetupHttpClient(client, headers);
                try
                {
                    var body = $"grant_type=password&username={username}&password={password}";

                    var response = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, ContentTypeConstants.APPLICATION_FORM_URL_ENCODED))
                        .ConfigureAwait(false);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var stringfiedContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        var deserializedData = !string.IsNullOrWhiteSpace(stringfiedContent)
                            ? JsonConvert.DeserializeObject<TOutput>(stringfiedContent)
                            : null;

                        return deserializedData;
                    }
                }
                catch (WebException)
                {
                    CoreServices.NetworkService.SignalServerConnectionDown();
                }
                catch (Exception ex)
                {
                    CoreServices.LoggingService.LogException(ex);
                }
            }

            return null;
        }

        #endregion

        #region Private methods

        private static bool HasInternetConnection()
        {
            if (CoreServices.NetworkService.DeviceHasInternetConnectivity())
            {
                return true;
            }

            CoreServices.NetworkService.SignalNoInternetConnection();
            return false;
        }

        private static string GenerateQueryString(IDictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            var count = 0;
            var sb = new StringBuilder();
            foreach (var entry in parameters)
            {
                if (count == 0)
                {
                    sb.Append("?");
                }
                else
                {
                    if (count != parameters.Count)
                    {
                        sb.Append("&");
                    }
                }
                sb.Append($"{entry.Key}={entry.Value}");
                count++;
            }

            return sb.ToString();
        }

        private static void SetupHttpClient(HttpClient client, IDictionary<string, string> headers)
        {
            try
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentTypeConstants.APPLICATION_JSON));
                client.BaseAddress = new Uri(ApiConstants.REST_SERVER_ROOT_URL);

                if (headers == null)
                {
                    return;
                }
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            catch (Exception ex)
            {
                CoreServices.LoggingService.LogException(ex);
            }
        }

        private string RetrieveUrlFromApiEndpoint(ApiEndpoint apiEndpoint, IDictionary<string, string> parameters)
        {
            if (!mApiEndpointUrlMappings.ContainsKey(apiEndpoint))
            {
                return null;
            }

            var apiUrl = mApiEndpointUrlMappings[apiEndpoint].Url;

            if (parameters != null && parameters.Count > 0)
            {
                var queryString = GenerateQueryString(parameters);
                if (!string.IsNullOrWhiteSpace(queryString))
                {
                    apiUrl = $"{apiUrl}{queryString}";
                }
            }

            return $"{ApiConstants.REST_SERVER_ROOT_URL}/{apiUrl}";
        }

        #endregion

        #region Configuration

        private void ConfigureMappings()
        {
            mApiEndpointUrlMappings.Add(ApiEndpoint.Register, new ApiEndpointContainer("User/Register", HttpMethod.Post));
            mApiEndpointUrlMappings.Add(ApiEndpoint.LogIn, new ApiEndpointContainer("User/Login", HttpMethod.Post));
        }

        #endregion
    }
}
