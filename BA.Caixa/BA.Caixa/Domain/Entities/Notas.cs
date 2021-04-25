using System;

namespace BA.Caixa.Domain.Entities
{
    public class Notas
    {
        public Guid Id { get; set; }
        public int Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
