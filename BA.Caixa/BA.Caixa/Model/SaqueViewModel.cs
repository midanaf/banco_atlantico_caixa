using System.Collections.Generic;

namespace BA.Caixa.Model
{
    public class SaqueResponse
    {
        public int Valor { get; set; }
        public List<ComposicaoViewModel> Composicao { get; set; }
        public SaqueResponse(int valor)
        {
            Valor = valor;
            Composicao = new List<ComposicaoViewModel>();
        }
    }

    public class ComposicaoViewModel
    {
        public int Quantidade { get; set; }
        public int Valor { get; set; }
    }

    public class SaqueRequest
    {
        public int Valor { get; set; }
    }
}
