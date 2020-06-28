using System.Threading.Tasks;
using WebApi.CalculadoraDeJuros.Domain.ValueObjects;

namespace WebApi.CalculadoraDeJuros.Interfaces
{
    public interface ITaxaJurosAPI
    {
        Task<CalculadoraJurosTaxaJuros> ObterTaxaJuros();
    }
}
