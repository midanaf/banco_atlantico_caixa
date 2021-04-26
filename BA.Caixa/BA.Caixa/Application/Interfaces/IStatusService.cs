using BA.Caixa.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BA.Caixa.Application.Interfaces
{
    public interface IStatusService
    {
        Task<IActionResult> Cadastrar(StatusViewModel status);
        bool Ativo();
        Task<IActionResult> ObterUltimo();
        Task<IActionResult> Listar();
    }
}
