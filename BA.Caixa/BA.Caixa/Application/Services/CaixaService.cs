using BA.Caixa.Application.Interfaces;
using BA.Caixa.Controllers.Shared;
using BA.Caixa.Domain.Interfaces;
using BA.Caixa.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Caixa.Application.Services
{
    public class CaixaService : ICaixaService
    {
        public INotaRepository _notaRepository;

        public CaixaService(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<IActionResult> Sacar(SaqueRequest saque)
        {
            var valorSolicitado = saque.Valor;
            var response = new SaqueResponse(valorSolicitado);
            var saldoCliente = ObterSaldoCliente();

            if (saldoCliente < valorSolicitado)
                return new BadRequestObjectResult("Saldo Insuficiente.");

            var maiorCedula = ObterMaiorCedula();

            var quantidadeCedula = 0;

            while (true)
            {
                if (valorSolicitado >= maiorCedula)
                {
                    valorSolicitado -= maiorCedula;
                    quantidadeCedula += 1;
                }
                else
                {
                    if (quantidadeCedula > 0)
                    {
                        response.Composicao.Add(new ComposicaoViewModel()
                        {
                            Quantidade = quantidadeCedula,
                            Valor = maiorCedula
                        });
                    }
                    quantidadeCedula = 0;
                    if (valorSolicitado == 0)
                    {
                        return new OkObjectResult(response);
                    }
                    if (maiorCedula == 0)
                    {
                        return new BadRequestObjectResult("Valor Solicitado não pode ser sacado.");
                    }
                    maiorCedula = ObterProximoMaiorValor(maiorCedula);
                }
            }

            return new OkObjectResult("");
        }

        private int ObterProximoMaiorValor(int maiorCedula)
        {
            var nota = _notaRepository.Listar().OrderByDescending(n => n.Valor).Select(x => x.Valor).ToArray();
            var indice = Array.IndexOf(nota, maiorCedula);

            if (indice > nota.Length)
            {
                return 0;
            }

            return nota[indice + 1];
        }

        private int ObterMaiorCedula()
        {
            var nota = _notaRepository.Listar().OrderByDescending(n => n.Valor).FirstOrDefault();
            return nota.Valor;
        }

        private int ObterSaldoCliente()
        {
            return 2000;
        }
    }
}
