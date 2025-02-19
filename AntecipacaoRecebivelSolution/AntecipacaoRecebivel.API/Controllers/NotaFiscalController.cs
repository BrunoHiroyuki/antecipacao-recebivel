using AntecipacaoRecebivel.Infrastructure.Data.Interfaces;
using AntecipacaoRecebivel.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AntecipacaoRecebivel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : Controller
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalController(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        /// <summary>
        /// Cadastra Notas Fiscais
        /// </summary>
        /// <param name="notaFiscal"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] NotaFiscal notaFiscal)
        {
            _notaFiscalRepository.Cadastrar(notaFiscal);
            return Ok();
        }

        /// <summary>
        /// Remove Notas Fiscais
        /// </summary>
        /// <param name="notaFiscal"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Remover/{numeroNotaFiscal}")]
        public IActionResult Remover(int numeroNotaFiscal)
        {
            _notaFiscalRepository.Remover(numeroNotaFiscal);
            return Ok();
        }
    }
}
