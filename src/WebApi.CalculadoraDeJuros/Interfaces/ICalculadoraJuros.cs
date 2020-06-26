using System.Threading.Tasks;
using WebApi.CalculadoraDeJuros.Domain.ValueObjects;

namespace WebApi.CalculadoraDeJuros.Interfaces
{
    public interface ICalculadoraJuros
    {
        Task<CalculadoraJurosDecimalPositivo> CalculaJurosAsync(CalculadoraJurosValorInicial valorInicial, CalculadoraJurosMeses numeroMeses); 
    }
}
