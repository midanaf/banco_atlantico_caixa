using BA.Caixa.Application.Interfaces;
using BA.Caixa.Controllers.Shared;
using BA.Caixa.Domain.Entities;
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

            var cedulaInicial = ObterMaiorCedula();

            if (cedulaInicial == null) return new BadRequestObjectResult("Cedulas Insuficiente.");

            var maiorCedula = cedulaInicial.Valor;
            var quantidadeCedula = 0;
            var quantidadeCedulaDisponivel = cedulaInicial.Quantidade;

            while (true)
            {

                if (maiorCedula == 0)
                {
                    return new BadRequestObjectResult("Valor Solicitado não pode ser sacado.");
                }
                if (valorSolicitado >= maiorCedula && quantidadeCedulaDisponivel > 0)
                {
                    valorSolicitado -= maiorCedula;
                    quantidadeCedulaDisponivel -= 1;
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
                        response.Composicao.ForEach(item => { SubtrairNota(item); });
                        //Chama serviço da conta do cliente para subtrair valor
                        return new OkObjectResult(response);
                    }
                    var maiorValor = ObterProximoMaiorValor(maiorCedula);
                    maiorCedula = maiorValor.Valor;
                    quantidadeCedulaDisponivel = maiorValor.Quantidade;
                }
            }
        }

        private void SubtrairNota(ComposicaoViewModel item)
        {
            var nota = _notaRepository.Listar().Where(x => x.Valor == item.Valor).FirstOrDefault();
            nota.Quantidade = nota.Quantidade - item.Quantidade;

            _notaRepository.Atualizar(nota);
        }

        private Notas ObterProximoMaiorValor(int maiorCedula)
        {
            var nota = _notaRepository.Listar().Where(x => x.Quantidade > 0).OrderByDescending(n => n.Valor);

            var valores = nota.Select(x => x.Valor).ToArray();
            var indice = Array.IndexOf(valores, maiorCedula);

            if (indice > valores.Length)
            {
                return null;
            }

            var valor = valores[indice + 1];

            return nota.FirstOrDefault(x => x.Valor == valor);
        }

        private Notas ObterMaiorCedula()
        {
            var nota = _notaRepository.Listar().OrderByDescending(n => n.Valor).FirstOrDefault(x => x.Quantidade > 0);

            if (nota == null)
            {
                return null;
            }
            return nota;
        }

        /// <summary>
        /// Obter Saldo do Cliente
        /// Este método vai se comunicar com serviço da conta do cliente obtendo saldo
        /// </summary>
        /// <returns></returns>
        private int ObterSaldoCliente()
        {
            return 2000;
        }
    }
}
