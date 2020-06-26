using System.Threading.Tasks;
using WebApi.CalculadoraDeJuros.Domain.ValueObjects;
using WebApi.CalculadoraDeJuros.Interfaces;

namespace WebApi.CalculadoraDeJuros.Tests.MockServices
{
    public class MockTaxaJurosAPIWebService : ITaxaJurosAPI
    {
        public Task<CalculadoraJurosTaxaJuros> ObterTaxaJuros()
        {
            return Task.FromResult(new CalculadoraJurosTaxaJuros("0,01"));
        }
    }
}
