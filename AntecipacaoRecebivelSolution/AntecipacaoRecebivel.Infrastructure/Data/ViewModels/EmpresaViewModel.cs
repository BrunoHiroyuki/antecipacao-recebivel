using AntecipacaoRecebivel.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntecipacaoRecebivel.Infrastructure.Data.ViewModels
{
    public class EmpresaViewModel
    {
        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter 14 dígitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O CNPJ deve conter apenas números")]
        [ValidaCnpj(ErrorMessage = "CNPJ com valor inválido")]
        public string Cnpj { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Faturamento Mensal é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "O faturamento mensal deve ser maior que zero")]
        public decimal FaturamentoMensal { get; set; }

        [Required(ErrorMessage = "Ramo é obrigatório")]
        public string Ramo { get; set; } = string.Empty;
    }
}
