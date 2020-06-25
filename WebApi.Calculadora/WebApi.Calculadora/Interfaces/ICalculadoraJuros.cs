namespace WebApi.Calculadora.Interfaces
{
    public interface ICalculadoraJuros
    {
        double CalculaJuros(decimal valorInicial, int numeroMeses, decimal taxaJuros); 
    }
}
