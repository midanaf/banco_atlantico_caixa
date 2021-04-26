using BA.Caixa.Application.Interfaces;
using BA.Caixa.Domain.Interfaces;
using BA.Caixa.Mapper;
using BA.Caixa.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Caixa.Application.Services
{
    public class StatusService : IStatusService
    {
        public IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Cadastrar(StatusViewModel status)
        {
            status.Horario = DateTime.Now;
            _repository.Salvar(status.ViewModelToEntity());

            return new OkObjectResult(status);
        }

        public bool Ativo()
        {
            var status = _repository.Listar().OrderByDescending(s => s.Horario).FirstOrDefault();
            if (status != null && status.Nome == "Ativo") return true;

            return false;
        }

        public async Task<IActionResult> ObterUltimo()
        {
            var status = _repository.Listar().OrderByDescending(s => s.Horario).FirstOrDefault();
            if (status == null)
            {
                return new OkObjectResult(new StatusViewModel());
            }
            else
            {
                return new OkObjectResult(status.EntityToViewModel());
            }
        }

        public async Task<IActionResult> Listar()
        {
            var status = _repository.Listar().ToList();
            if (status == null)
            {
                return new OkObjectResult(new List<StatusViewModel>());
            }
            else
            {
                return new OkObjectResult(status.EntityToViewModel());
            }
        }
    }
}
