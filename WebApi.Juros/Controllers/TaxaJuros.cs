using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Juros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJuros : Controller
    {
        /// <summary>
        /// Obtém a taxa de juros (1% ou 0.01)
        /// </summary>
        /// <response code="200">Solicitação foi concluída com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado no servidor.</response>
        /// <returns>Retorna um double com a taxa de juros.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            return new OkObjectResult(0.01);
        }
    }
}
