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
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmpresaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Cadastrar(Empresa empresa)
        {
            _dbContext.Empresas.Add(empresa);
            _dbContext.SaveChanges();
        }
    }
}
