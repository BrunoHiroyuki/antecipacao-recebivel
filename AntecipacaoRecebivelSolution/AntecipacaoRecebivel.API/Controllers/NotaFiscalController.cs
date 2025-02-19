using AntecipacaoRecebivel.Infrastructure.Data.Interfaces;
using AntecipacaoRecebivel.Infrastructure.Data.Models;
using AntecipacaoRecebivel.Infrastructure.Data.ViewModels;
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
        /// <param name="notaFiscalVM"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] NotaFiscalViewModel notaFiscalVM)
        {
            try
            {
                var notaFiscal = new NotaFiscal() 
                { 
                    Numero = notaFiscalVM.Numero,
                    EmpresaCNPJ = notaFiscalVM.EmpresaCNPJ,
                    Valor = notaFiscalVM.Valor,
                    Vencimento = notaFiscalVM.Vencimento,
                };

                _notaFiscalRepository.Cadastrar(notaFiscal);
                return Ok("Nota Fiscal cadastrada com sucesso");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
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
            try
            {
                _notaFiscalRepository.Remover(numeroNotaFiscal);
                return Ok("Nota Fiscal removida com sucesso");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
