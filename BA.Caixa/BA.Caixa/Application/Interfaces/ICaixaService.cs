using BA.Caixa.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BA.Caixa.Application.Interfaces
{
    public interface ICaixaService
    {
        Task<IActionResult> Sacar(SaqueRequest saque);
    }
}
