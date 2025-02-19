using AntecipacaoRecebivel.Infrastructure.Context;
using AntecipacaoRecebivel.Infrastructure.Data.Interfaces;
using AntecipacaoRecebivel.Infrastructure.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntecipacaoRecebivel.Infrastructure.Data.Repositories
{
    public class CarrinhoAntecipacaoRepository : ICarrinhoAntecipacaoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarrinhoAntecipacaoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CalculoAntecipacaoViewModel Calcular(string cnpj)
        {
            // Buscamos a empresa no banco
            var empresa = _dbContext.Empresas.AsNoTracking().FirstOrDefault(f => f.Cnpj == cnpj) ?? throw new Exception("CNPJ inválido ou empresa não cadastrada na base");

            // Buscamos todas as notas fiscais da empresa
            var notasFiscais = _dbContext.NotasFiscais.AsNoTracking().Where(w => w.EmpresaCNPJ == cnpj);

            // Retornamos a viewmodel com os valores calculados
            return new CalculoAntecipacaoViewModel
            {
                EmpresaCnpj = empresa.Cnpj,
                EmpresaNome = empresa.Nome,
                EmpresaLimiteAntecipacao = empresa.LimiteAntecipacao,
                NotasFiscais = notasFiscais.Select(s => new CalculoNotaFiscalViewModel() 
                {
                    Numero = s.Numero,
                    ValorBruto = s.Valor,
                    Vencimento = s.Vencimento,
                }).ToList()
            };
        }
    }
}
