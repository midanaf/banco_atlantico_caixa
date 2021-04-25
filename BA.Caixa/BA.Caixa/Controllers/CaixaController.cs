using BA.Caixa.Application.Interfaces;
using BA.Caixa.Controllers.Shared;
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
        [ProducesResponseType(typeof(ApiResult<SaqueResponse>), StatusCodes.Status200OK)]
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
                return UnprocessableEntity(ApiResult.Fail("Não foi possível Sacar o valor solicitado"));
            }
        }
    }
}
