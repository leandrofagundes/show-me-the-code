using System.Threading.Tasks;
using WebApi.Calculadora.Domain.ValueObjects;

namespace WebApi.Calculadora.Interfaces
{
    public interface ICalculadoraJuros
    {
        Task<CalculadoraJurosDecimalPositivo> CalculaJurosAsync(CalculadoraJurosValorInicial valorInicial, CalculadoraJurosMeses numeroMeses); 
    }
}
