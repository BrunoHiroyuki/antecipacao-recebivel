using AntecipacaoRecebivel.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static AntecipacaoRecebivel.Infrastructure.Data.Models.Empresa;

namespace AntecipacaoRecebivel.Infrastructure.Data.ViewModels
{
    public class CalculoAntecipacaoViewModel
    {
        [JsonPropertyName("empresa")]
        public string EmpresaNome { get; set; } = string.Empty;

        [JsonPropertyName("cnpj")]
        public string EmpresaCnpj { get; set; } = string.Empty;

        [JsonPropertyName("limite")]
        public decimal EmpresaLimiteAntecipacao { get; set; }

        [JsonPropertyName("notas_fiscais")]
        public List<CalculoNotaFiscalViewModel> NotasFiscais { get; set; } = new List<CalculoNotaFiscalViewModel>();

        [JsonPropertyName("total_liquido")]
        public decimal TotalLiquido
        {
            get
            {
                return NotasFiscais.Sum(s => s.ValorLiquido);
            }
        }

        [JsonPropertyName("total_bruto")]
        public decimal TotalBruto
        {
            get
            {
                return NotasFiscais.Sum(s => s.ValorBruto);
            }
        }
    }

    public class CalculoNotaFiscalViewModel
    {
        [JsonPropertyName("numero")]
        public int Numero { get; set; }

        [JsonPropertyName("valor_bruto")]
        public decimal ValorBruto { get; set; }

        [JsonPropertyName("valor_liquido")]
        public decimal ValorLiquido
        {
            get
            {
                return ValorBruto - Desagio;
            }
        }

        [JsonIgnore]
        public DateTime Vencimento { get; set; } = DateTime.Today;

        public int Prazo
        {
            get
            {
                return (DateTime.Today - Vencimento.Date).Days;
            }
        }

        [JsonIgnore]
        public static double Taxa => 0.0465;

        [JsonIgnore]
        public decimal Desagio
        {
            get
            {
                return (decimal)((double)ValorBruto / ((1 + Taxa) * (Prazo / 30)));
            }
        }
    }
}
