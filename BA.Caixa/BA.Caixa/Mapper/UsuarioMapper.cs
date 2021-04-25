using BA.Caixa.Domain.Entities;
using BA.Caixa.Model;

namespace BA.Caixa.Mapper
{
    public static class UsuarioMapper
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
    }
}
