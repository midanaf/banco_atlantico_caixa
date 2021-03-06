using BA.Caixa.Domain.Entities;
using System.Collections.Generic;

namespace BA.Caixa.Domain.Interfaces
{
    public interface IStatusRepository
    {
        void Salvar(Status status);
        IEnumerable<Status> Listar();
    }
}
