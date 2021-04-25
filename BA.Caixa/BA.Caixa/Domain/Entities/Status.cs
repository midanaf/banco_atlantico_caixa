using System;

namespace BA.Caixa.Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public DateTime Horario { get; set; }
    }
}
