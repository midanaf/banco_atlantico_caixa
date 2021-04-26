using BA.Caixa.Domain.Entities;
using BA.Caixa.Model;
using System.Collections.Generic;

namespace BA.Caixa.Mapper
{
    public static class StatusMapper
    {
        public static Status ViewModelToEntity(this StatusViewModel status)
        {
            return new Status()
            {
                Descricao = status.Descricao,
                Horario = status.Horario,
                Id = status.Id,
                Nome = status.Nome
            };
        }

        public static StatusViewModel EntityToViewModel(this Status status)
        {
            return new StatusViewModel()
            {
                Descricao = status.Descricao,
                Horario = status.Horario,
                Id = status.Id,
                Nome = status.Nome
            };
        }

        public static List<StatusViewModel> EntityToViewModel(this List<Status> status)
        {
            var resultado = new List<StatusViewModel>();
            foreach (var item in status)
            {
                resultado.Add(item.EntityToViewModel());
            }

            return resultado;
        }
    }
}
