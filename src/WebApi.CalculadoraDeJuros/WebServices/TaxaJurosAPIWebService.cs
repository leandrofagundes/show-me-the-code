using System.Net.Http;
using System.Threading.Tasks;
using WebApi.CalculadoraDeJuros.Domain.Exceptions;
using WebApi.CalculadoraDeJuros.Domain.ValueObjects;
using WebApi.CalculadoraDeJuros.Interfaces;

namespace WebApi.CalculadoraDeJuros.WebServices
{
    public class TaxaJurosAPIWebService
        : ITaxaJurosAPI
    {
        private readonly HttpClient _httpClient;

        public TaxaJurosAPIWebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CalculadoraJurosTaxaJuros> ObterTaxaJuros()
        {
            var response = await _httpClient.GetAsync("taxaJuros");
            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                return new CalculadoraJurosTaxaJuros(resultString);
            }
            else
                throw new InvalidTaxaJurosAPIResponse("Não foi possível conectar ao serviço de Taxa de Juros.");
        }
    }
}
