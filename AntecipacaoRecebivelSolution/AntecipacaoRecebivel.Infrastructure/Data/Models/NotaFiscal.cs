using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntecipacaoRecebivel.Infrastructure.Data.Models
{
    [Table("NotaFiscal")]
    public class NotaFiscal
    {
        [Key]
        public int Numero { get; set; }

        [Required(ErrorMessage = "CNPJ da empresa é obrigatório")]
        [ForeignKey("Empresa")]
        public string EmpresaCNPJ { get; set; } = string.Empty;
        public virtual Empresa Empresa { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data de Vencimento é obrigatório")]
        public DateTime Vencimento { get; set; } = DateTime.Today;
    }
}
