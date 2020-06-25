using System.Threading.Tasks;
using WebApi.Calculadora.Domain.ValueObjects;
using WebApi.Calculadora.Interfaces;

namespace WebApi.Calculadora.Tests.MockServices
{
    public class MockTaxaJurosAPIWebService : ITaxaJurosAPI
    {
        public Task<CalculadoraJurosTaxaJuros> ObterTaxaJuros()
        {
            return Task.FromResult(new CalculadoraJurosTaxaJuros("0,01"));
        }
    }
}
