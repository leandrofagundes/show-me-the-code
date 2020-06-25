using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Juros.Services;

namespace WebApi.Juros.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar requisições referentes a taxa de juros.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : Controller
    {
        /// <summary>
        /// Obtém a taxa de juros (1% ou 0.01 fixa)
        /// </summary>
        /// <response code="200">Solicitação foi concluída com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado no servidor.</response>
        /// <returns>Retorna um decimal formatado na cultura pt-br com a taxa de juros.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromServices] TaxaJurosService taxaJurosService)
        {
            var taxaJuros = taxaJurosService.ObterTaxaJuros();
            return new OkObjectResult(taxaJuros.ToString());
        }
    }
}
