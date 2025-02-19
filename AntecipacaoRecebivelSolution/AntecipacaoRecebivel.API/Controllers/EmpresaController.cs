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
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody]Empresa empresa)
        {
            _empresaRepository.Cadastrar(empresa);
            return Ok();
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
