using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.CalculadoraDeJuros.Interfaces;

namespace WebApi.CalculadoraDeJuros.Controllers
{
    /// <summary>
    /// Controller responsável por retornar a url aonde o código fonte encontra-se.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : Controller
    {
        /// <summary>
        /// Retorna a url do repositório de fontes.
        /// </summary>
        /// <response code="200">Solicitação foi concluída com sucesso.</response>
        /// <response code="500">Ocorreu um erro inesperado no servidor.</response>
        /// <returns>Retorna uma string com a url do repositório de fontes.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromServices] IShowMeTheCode showMeTheCodeService)
        {
            var repositoryUrl = showMeTheCodeService.GetUrl();
            return new OkObjectResult(repositoryUrl);
        }
    }
}
