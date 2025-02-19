using AntecipacaoRecebivel.Infrastructure.Data.Interfaces;
using AntecipacaoRecebivel.Infrastructure.Data.Models;
using AntecipacaoRecebivel.Infrastructure.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AntecipacaoRecebivel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        /// <summary>
        /// Cadastra Empresa na base
        /// </summary>
        /// <param name="empresaVM"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody]EmpresaViewModel empresaVM)
        {
            // Verifica se a string do campo Ramo corresponde aos valores registrados no enum
            if (Enum.TryParse(empresaVM.Ramo, true, out Empresa.TipoRamo ramo))
            {
                var empresa = new Empresa()
                {
                    Cnpj = empresaVM.Cnpj,
                    FaturamentoMensal = empresaVM.FaturamentoMensal,
                    Nome = empresaVM.Nome,
                    Ramo = ramo,
                };

                _empresaRepository.Cadastrar(empresa);
                return Ok();
            }
            else
            {
                return BadRequest("Ramo da empresa inválido. O ramo deve ser de Produtos ou Serviços");
            }
        }

        /// <summary>
        /// Lista todas as empresas cadastradas na base
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        public IEnumerable<EmpresaViewModel> Listar()
        {
            return _empresaRepository.Listar();
        }
    }
}
