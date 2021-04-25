using BA.Caixa.Data.Context;
using BA.Caixa.Domain.Entities;
using BA.Caixa.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BA.Caixa.Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        public AppDbContext _context;

        public NotaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Atualizar(Notas notas)
        {
            _context.Update(notas);
            _context.SaveChanges();
        }

        public List<Notas> Listar()
        {
            return _context.Notas.AsNoTracking().ToList();
        }
    }
}
