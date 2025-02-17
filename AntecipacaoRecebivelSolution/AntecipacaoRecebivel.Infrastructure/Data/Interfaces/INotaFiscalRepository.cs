using AntecipacaoRecebivel.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntecipacaoRecebivel.Infrastructure.Data.Interfaces
{
    public interface INotaFiscalRepository
    {
        void Cadastrar(NotaFiscal notaFiscal);
    }
}
