using BA.Caixa.Application.Interfaces;
using BA.Caixa.Domain.Interfaces;
using BA.Caixa.Mapper;
using BA.Caixa.Model;
using System.Linq;

namespace BA.Caixa.Application.Services
{
    public class StatusService : IStatusService
    {
        public IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository;
        }

        public void Cadastrar(StatusViewModel usuario)
        {
            _repository.Salvar(usuario.ViewModelToEntity());
        }

        public bool Ativo()
        {
            var status = _repository.Listar().OrderByDescending(s => s.Horario).FirstOrDefault();
            if (status != null && status.Nome == "Ativo") return true;

            return false;
        }

        public StatusViewModel Obter()
        {
            var status = _repository.Listar().OrderByDescending(s => s.Horario).FirstOrDefault();
            if (status == null)
            {
                return null;
            }
            else
            {
                return status.EntityToViewModel();
            }
        }
    }
}
