using System.Threading.Tasks;
using WebApi.Calculadora.Domain.ValueObjects;

namespace WebApi.Calculadora.Interfaces
{
    public interface ITaxaJurosAPI
    {
        Task<CalculadoraJurosTaxaJuros> ObterTaxaJuros();
    }
}
