using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace vexpenses.business.Components
{
    public class RestfullComponent
    {
        private readonly HttpClient _httpCleint;

        public RestfullComponent(HttpClient httpClient)
        {
            _httpCleint = httpClient;
        }

        public async Task<TResponse> GetAsync<TResponse>(string endpointWithParameters)
        {
            var responseMessage = await _httpCleint.GetAsync(endpointWithParameters);

            var response = await ManageResponse<TResponse>(responseMessage);

            return response;
        }
        private T DeserializeObject<T>(string json)
        {
            try
            {
                var settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

                var deserializedObject = JsonConvert.DeserializeObject<T>(json, settings);

                return deserializedObject;
            }
            catch (Exception ex)
            {
                var exception = new Exception($"Erro ao buscar dados referentes ao endereço solicitado", ex);
                throw exception;
            }
        }

        private async Task<TResponse> ManageResponse<TResponse>(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                var successResponseString = await responseMessage.Content.ReadAsStringAsync();

                var successResponseObject = DeserializeObject<TResponse>(successResponseString);

                return successResponseObject;
            }
            else
            {
                throw new Exception("Erro ao buscar dados referentes ao endereço solicitado");
            }
        }
    }
}
