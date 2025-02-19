using AntecipacaoRecebivel.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntecipacaoRecebivel.Infrastructure.Data.ViewModels
{
    public class NotaFiscalViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Número da nota deve ser maior que zero")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "CNPJ da empresa é obrigatório")]
        public string EmpresaCNPJ { get; set; } = string.Empty;

        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data de Vencimento é obrigatório")]
        public DateTime Vencimento { get; set; } = DateTime.Today;
    }
}
