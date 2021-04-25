using BA.Caixa.Model;
using System;

namespace BA.Caixa.Application.Interfaces
{
    public interface IStatusService
    {
        void Cadastrar(StatusViewModel usuario);
        bool Ativo();
        StatusViewModel Obter();
    }
}
