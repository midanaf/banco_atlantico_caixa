using BA.Caixa.Application.Interfaces;
using BA.Caixa.Domain.Entities;
using BA.Caixa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BA.Caixa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaixaController : Controller
    {
        private readonly ILogger<CaixaController> _logger;
        private ICaixaService _service;

        public CaixaController(ILogger<CaixaController> logger, ICaixaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("Sacar")]
        [ProducesResponseType(typeof(SaqueResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Cadastrar([FromBody] SaqueRequest model)
        {
            try
            {
                return await  _service.Sacar(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity("Não foi possível Sacar o valor solicitado");
            }
        }

        [HttpGet("Cedulas")]
        [ProducesResponseType(typeof(Notas), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CadasGetCedulastrar()
        {
            try
            {
                return await _service.ListarCedulas();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity("Não foi listar as cedulas.");
            }
        }
    }
}
