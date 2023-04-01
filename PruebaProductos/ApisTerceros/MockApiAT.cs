using Entidades.Clases;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApisTerceros
{
    public class MockApiAT : IMockApiAT
    {
        private readonly HttpClient _httpClient;
        public MockApiAT(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            string rutaBaseMockApi = configuration.GetSection("Apis:MockApi").Value;
            rutaBaseMockApi = string.IsNullOrEmpty(rutaBaseMockApi) ? "https://6426ef34556bad2a5b5bb208.mockapi.io/" : rutaBaseMockApi;
            _httpClient.BaseAddress = new Uri(rutaBaseMockApi);
        }

        public decimal ObtenerDescuento(int ProductId)
        {
            DescuentoMockApiENT descuentoMockApiENT = new DescuentoMockApiENT();
            var response = _httpClient.GetAsync("api/v1/obtenerdescuento/descuentos/" + ProductId.ToString()).Result;
            response.EnsureSuccessStatusCode();
            string? content = response.Content.ReadAsStringAsync().Result;


            if (!string.IsNullOrEmpty(content))
                descuentoMockApiENT = JsonSerializer.Deserialize<DescuentoMockApiENT>(content);

            return descuentoMockApiENT.descuento;
        }
    }
}