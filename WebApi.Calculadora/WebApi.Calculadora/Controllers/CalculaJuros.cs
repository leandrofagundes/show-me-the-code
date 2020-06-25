using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Calculadora.Interfaces;

namespace WebApi.Juros.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar requisições referentes a calculadora de Juros.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CalculaJuros : Controller
    {
        /// <summary>
        /// Efetua o cálculo do juros composto baseado nos valores obtidos por parãmetros
        /// </summary>
        /// <response code="200">Solicitação foi concluída com sucesso.</response>
        /// <response code="400">Sua solicitação apresentou valores inválidos e por isso será rejeitada.</response>
        /// <response code="500">Ocorreu um erro inesperado no servidor.</response>
        /// <returns>Retorna um double com a taxa de juros.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(double))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromServices] ICalculadoraJuros calculadoraJurosCompostoService)
        {
            var jurosComposto = calculadoraJurosCompostoService.CalculaJuros(0, 0, 0);
            return new OkObjectResult(jurosComposto);
        }
    }
}
