using AntecipacaoRecebivel.Infrastructure.Context;
using AntecipacaoRecebivel.Infrastructure.Data.Interfaces;
using AntecipacaoRecebivel.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
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
            // Verifica se já existe uma nota com o mesmo número no banco
            var notaFiscalNumero = _dbContext.NotasFiscais.AsNoTracking().FirstOrDefault(a => a.Numero == notaFiscal.Numero);
            if(notaFiscalNumero != null) throw new Exception("Já existe uma Nota Fiscal cadastrada com esse número");

            // Fazemos a busca se a empresa já está cadastrada no banco
            var empresa = _dbContext.Empresas.AsNoTracking().FirstOrDefault(f => f.Cnpj == notaFiscal.EmpresaCNPJ) ?? throw new Exception("Empresa não cadastrada na base ou CNPJ inválido");

            // Somamos o valor das notas fiscais da empresa presentes no banco 
            var valorNotasFiscais = _dbContext.NotasFiscais.AsNoTracking().Where(w => w.EmpresaCNPJ == empresa.Cnpj).Sum(s => s.Valor);

            // Caso a soma das notas existentes com a nota a ser inserida for maior que o limite de antecipação, interromper o cadastro
            if (valorNotasFiscais + notaFiscal.Valor > empresa.LimiteAntecipacao) throw new Exception("Valor das notas fiscais ultrapassa o limite de crédito da empresa");

            _dbContext.NotasFiscais.Add(notaFiscal);
            _dbContext.SaveChanges();
        }

        public void Remover(int numero)
        {
            var notaFiscal = _dbContext.NotasFiscais.FirstOrDefault(f => f.Numero == numero) ?? throw new Exception("Nota não encontrada na base");
            _dbContext.NotasFiscais.Remove(notaFiscal);
            _dbContext.SaveChanges();
        }
    }
}
