using AntecipacaoRecebivel.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntecipacaoRecebivel.Infrastructure.Data.Interfaces
{
    public interface ICarrinhoAntecipacaoRepository
    {
        CalculoAntecipacaoViewModel Calcular(string cnpj);
    }
}
