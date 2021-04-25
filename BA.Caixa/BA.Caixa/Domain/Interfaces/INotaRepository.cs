using BA.Caixa.Domain.Entities;
using System.Collections.Generic;

namespace BA.Caixa.Domain.Interfaces
{
    public interface INotaRepository
    {
        List<Notas> Listar();
    }
}
