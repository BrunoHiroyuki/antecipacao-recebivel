using AntecipacaoRecebivel.Infrastructure.Context;
using AntecipacaoRecebivel.Infrastructure.Data.Interfaces;
using AntecipacaoRecebivel.Infrastructure.Data.Models;
using AntecipacaoRecebivel.Infrastructure.Data.ViewModels;
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

        public IEnumerable<EmpresaViewModel> Listar()
        {
            return _dbContext.Empresas.Select(s => new EmpresaViewModel
            {
                Cnpj = s.Cnpj,
                FaturamentoMensal = s.FaturamentoMensal,
                Nome = s.Nome,
                Ramo = s.Ramo.ToString()
            });
        }

        public void Cadastrar(Empresa empresa)
        {
            _dbContext.Empresas.Add(empresa);
            _dbContext.SaveChanges();
        }
    }
}
