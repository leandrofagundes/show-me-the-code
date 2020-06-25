namespace WebApi.Calculadora.DTOs
{
    public class CalculaJurosRequestDTO
    {
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
    }
}
