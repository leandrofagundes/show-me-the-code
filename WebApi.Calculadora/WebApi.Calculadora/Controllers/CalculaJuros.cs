using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Calculadora.Domain.Exceptions;
using WebApi.Calculadora.Domain.ValueObjects;
using WebApi.Calculadora.DTOs;
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
        public async Task<IActionResult> Get(
            [FromServices] ICalculadoraJuros calculadoraJurosCompostoService,
            [FromQuery]CalculaJurosRequestDTO requestData)
        {
            try
            {
                var valorInicial = new CalculadoraJurosValorInicial(requestData.ValorInicial);
                var meses = new CalculadoraJurosMeses(requestData.Meses);

                var jurosComposto = await calculadoraJurosCompostoService.CalculaJurosAsync(valorInicial, meses);

                return new OkObjectResult(jurosComposto.ToString());
            }
            catch (InvalidValueObjectDataException invalidDataEx)
            {
                return new BadRequestObjectResult($"{invalidDataEx.Message} Valor informado: {invalidDataEx.Value}");
            }
            catch (Exception)
            {
                return new ObjectResult("Ocorreu um erro inesperado no servidor. Entre em contato com nosso suporte")
                {
                    StatusCode = 500,
                };
            }
        }
    }
}
