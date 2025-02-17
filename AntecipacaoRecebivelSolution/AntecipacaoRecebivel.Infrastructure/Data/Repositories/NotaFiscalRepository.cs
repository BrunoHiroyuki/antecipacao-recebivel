using AntecipacaoRecebivel.Infrastructure.Context;
using AntecipacaoRecebivel.Infrastructure.Data.Interfaces;
using AntecipacaoRecebivel.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntecipacaoRecebivel.Infrastructure.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NotaFiscalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Cadastrar(NotaFiscal notaFiscal)
        {
            _dbContext.NotasFiscais.Add(notaFiscal);
            _dbContext.SaveChanges();
        }
    }
}
