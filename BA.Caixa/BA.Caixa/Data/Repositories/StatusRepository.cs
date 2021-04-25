using BA.Caixa.Data.Context;
using BA.Caixa.Domain.Entities;
using BA.Caixa.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BA.Caixa.Data.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        public AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Status> Listar()
        {
            return _context.Status.AsNoTracking().ToList();
        }

        public void Salvar(Status status)
        {
            _context.Add(status);
            _context.SaveChanges();
        }
    }
}
