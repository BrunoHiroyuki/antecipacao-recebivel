using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AntecipacaoRecebivel.Infrastructure.Data.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
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
        public TipoRamo Ramo { get; set; }

        public enum TipoRamo
        {
            Serviços = 0,
            Produtos = 1
        }

        [NotMapped]
        public decimal LimiteAntecipacao
        {
            get
            {
                return FaturamentoMensal * PorcentagemFaturamento;
            }
        }

        [NotMapped]
        public decimal PorcentagemFaturamento
        {
            get
            {
                if (10000 <= FaturamentoMensal && FaturamentoMensal <= 50000)
                {
                    return 0.5m;
                }
                else if (50000 < FaturamentoMensal && FaturamentoMensal <= 100000)
                {
                    return Ramo == TipoRamo.Serviços ? 0.55m : Ramo == TipoRamo.Produtos ? 0.6m : 0;
                }
                else if (FaturamentoMensal > 100000)
                {
                    return Ramo == TipoRamo.Serviços ? 0.6m : Ramo == TipoRamo.Produtos ? 0.65m : 0;
                }

                return 0;
            }
        }
    }

    public class ValidaCnpjAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value.GetType() != typeof(string)) return false;

            return IsCnpj((string)value);
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}