using BA.Caixa.Application.Interfaces;
using BA.Caixa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BA.Caixa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        private readonly ILogger<StatusController> _logger;
        private IStatusService _service;
        public StatusController(ILogger<StatusController> logger, IStatusService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(List<StatusViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return await _service.Listar();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity("Não foi possível listar Status");
            }
        }

        [HttpGet("ultimo")]
        [ProducesResponseType(typeof(StatusViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Ultimo()
        {
            try
            {
                return await _service.ObterUltimo();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity("Não foi possível apresentar o último status");
            }
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(StatusViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Cadastrar(StatusViewModel model)
        {
            try
            {
                return await _service.Cadastrar(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity("Não foi possível atualizar status.");
            }
        }
    }
}
