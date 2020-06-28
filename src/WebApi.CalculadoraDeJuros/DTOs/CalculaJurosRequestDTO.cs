namespace WebApi.CalculadoraDeJuros.DTOs
{
    public class CalculaJurosRequestDTO
    {
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
    }
}
